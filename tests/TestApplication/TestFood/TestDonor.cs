using Application.Common;
using Application.Dtos.FoodDtos;
using Application.Services.FoodService;
using AutoMapper;
using Domain.Entities.Food;
using FluentAssertions;
using Domain.Enums.Food;
using Domain.Interfaces;
using Moq;
using Xunit;
using DateOnly = System.DateOnly;

namespace TestApplication.TestFood;

public class TestFood
{
    private readonly Mock<IBaseRepository<Food>> _mock;
    private readonly IMapper _mapper;
    private readonly FoodService _service;

    public TestFood()
    {
        _mock = new Mock<IBaseRepository<Food>>();
        _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperConfig())));
        _service = new FoodService(_mock.Object, _mapper);
    }

    [Fact]
    public async Task ShouldCreateFoodSuccessfullyAsync()
    {
        var foodName = new FoodName("TestFood");
        var expirationDate = new DateOnly(2025, 12, 20);
        var dto = new FoodRequestDto { FoodName = foodName, State = 0, IsPerishable = true, ExpirationDate = expirationDate};

        var result = await _service.Insert(dto);

        var expectedResult = _mapper.Map<Food>(dto);
        
        _mock.Verify(m => m.AddAsync(It.IsAny<Food>()), Times.Once);
        _mock.Verify(m => m.SaveChangesAsync(), Times.Once);

        result.Should().BeEquivalentTo(expectedResult, opt => 
            opt.Excluding(x => x.Id));
    }

    [Fact]
    public async Task ShouldGetFoodByIdSuccessfullyAsync()
    {
        var foodName = new FoodName("TestFood");
        var expirationDate = new DateOnly(2025, 12, 20);
        var food = new Food(foodName, State.Solid, true, expirationDate);

        _mock.Setup(r => r.FindAsync(food.Id)).ReturnsAsync(food);

        var result = await _service.GetById(food.Id);

        var expectedResult = _mapper.Map<FoodResponseDto>(food);
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public Task ShouldGetAllFoodsSuccessfullyAsync()
    {
        var foodName = new FoodName("TestFood");
        var expirationDate = new DateOnly(2025, 12, 20);
        var foods = new List<Food>
        {
            new Food(foodName, State.Solid, true, expirationDate),
            new Food(foodName, State.Solid, true, expirationDate)
        };

        _mock.Setup(r => r.List()).Returns(foods);

        var result = _service.GetAll();

        var expectedResult = _mapper.Map<IEnumerable<FoodResponseDto>>(foods);
        result.Should().BeEquivalentTo(expectedResult);
        return Task.CompletedTask;
    }

    [Fact]
    public async Task ShouldEditFoodSuccessfullyAsync()
    {
        var foodName = new FoodName("TestFood");
        var expirationDate = new DateOnly(2025, 12, 20);
        var food = new Food(foodName, State.Liquid, false, expirationDate);
        var updatedFood = new Food(foodName, State.Solid, true, expirationDate);

        _mock.Setup(r => r.FindAsync(food.Id)).ReturnsAsync(food);
        _mock.Setup(r => r.Update(food)).Returns(updatedFood);

        var foodRequestEditDto = new FoodRequestDto
        {
            FoodName = foodName, State = State.Solid, IsPerishable = true, ExpirationDate = expirationDate
        };
        var result = await _service.Edit(food.Id, foodRequestEditDto);

        var expectedResult = _mapper.Map<FoodResponseDto>(updatedFood);
        result.Should().BeEquivalentTo(expectedResult);
    }
    
    [Fact]
    public async Task ShouldEditFoodFailed()
    {
        var foodId = Guid.NewGuid();
        var foodName = new FoodName("TestFood");
        var expirationDate = new DateOnly(2025, 12, 20);
        var food = new Food(foodName, State.Liquid, false, expirationDate);

        _mock.Setup(r => r.FindAsync(foodId)).ReturnsAsync(food);

        var ex = await Record.ExceptionAsync(async () => await _service.Edit(Guid.NewGuid(), new FoodRequestDto
        {
            FoodName = new FoodName("updateTestFood"),State = State.Solid, IsPerishable = true, ExpirationDate = expirationDate
        }));
            
        Assert.Equal($"No value found.", ex!.Message);
        Assert.Equal(typeof(ResourceNotFoundException), ex.GetType());
    }
    
    [Fact]
    public async Task ShouldDeleteFoodSuccessfullyAsync()
    {
        var foodId = Guid.NewGuid();
        var foodName = new FoodName("TestFood");
        var expirationDate = new DateOnly(2025, 12, 20);
        var food = new Food(foodName, State.Liquid, false, expirationDate);
        _mock.Setup(r => r.FindAsync(foodId)).ReturnsAsync(food);

        await _service.Delete(foodId);
            
        _mock.Verify(m => m.DeleteAsync(foodId), Times.Once);
        _mock.Verify(m => m.SaveChangesAsync(), Times.Once);
    }
    
    [Fact]
    public async Task ShouldDeleteFoodFailedAsync()
    {
        var foodId = Guid.NewGuid();
        Food food = null!;

        _mock.Setup(r => r.FindAsync(foodId)).ReturnsAsync(food);
            
        var ex = await Record.ExceptionAsync(async () => await _service.Delete(foodId));
            
        Assert.Equal($"No value found.", ex!.Message);
        Assert.Equal(typeof(ResourceNotFoundException), ex.GetType());
            
        _mock.Verify(m => m.DeleteAsync(foodId), Times.Never);
        _mock.Verify(m => m.SaveChangesAsync(), Times.Never);
    }
}