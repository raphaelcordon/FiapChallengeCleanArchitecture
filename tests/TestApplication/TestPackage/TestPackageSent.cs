using Application.Common;
using Application.Dtos.PackageDtos;
using Application.Services.PackageService;
using AutoMapper;
using Domain.Entities.Package;
using FluentAssertions;
using Domain.Interfaces;
using Moq;
using Xunit;

namespace TestApplication.TestPackage;

public class TestPackageSent
{
    private readonly Mock<IBaseRepository<PackageSent>> _mock;
    private readonly IMapper _mapper;
    private readonly PackageSentService _service;

    public TestPackageSent()
    {
        _mock = new Mock<IBaseRepository<PackageSent>>();
        _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperConfig())));
        _service = new PackageSentService(_mock.Object, _mapper);
    }
    
    private readonly List<Guid> _foodList = new List<Guid>{ Guid.NewGuid(), Guid.NewGuid() };

    [Fact]
    public async Task ShouldCreatePackageSentSuccessfullyAsync()
    {
        var dto = new PackageSentRequestDto { FoodList = _foodList, ReceiverId = Guid.NewGuid()};

        var result = await _service.Insert(dto);

        var expectedResult = _mapper.Map<PackageSent>(dto);
        
        _mock.Verify(m => m.AddAsync(It.IsAny<PackageSent>()), Times.Once);
        _mock.Verify(m => m.SaveChangesAsync(), Times.Once);

        result.Should().BeEquivalentTo(expectedResult, opt => 
            opt.Excluding(x => x.Id));
    }

    [Fact]
    public async Task ShouldGetPackageSentByIdSuccessfullyAsync()
    {
        var packageSent = new PackageSent(_foodList, Guid.NewGuid());

        _mock.Setup(r => r.FindAsync(packageSent.Id)).ReturnsAsync(packageSent);

        var result = await _service.GetById(packageSent.Id);

        var expectedResult = _mapper.Map<PackageSentResponseDto>(packageSent);
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public Task ShouldGetAllPackageSentSuccessfullyAsync()
    {
        var packagesSent = new List<PackageSent>
        {
            new PackageSent(_foodList, Guid.NewGuid()),
            new PackageSent(_foodList, Guid.NewGuid())
        };

        _mock.Setup(r => r.List()).Returns(packagesSent);

        var result = _service.GetAll();

        var expectedResult = _mapper.Map<IEnumerable<PackageSentResponseDto>>(packagesSent);
        result.Should().BeEquivalentTo(expectedResult);
        return Task.CompletedTask;
    }

    [Fact]
    public async Task ShouldEditPackageSentSuccessfullyAsync()
    {
        var packageSent = new PackageSent(_foodList, Guid.NewGuid());
        var updatedPackageSent = new PackageSent(_foodList, Guid.NewGuid());

        _mock.Setup(r => r.FindAsync(packageSent.Id)).ReturnsAsync(packageSent);
        _mock.Setup(r => r.Update(packageSent)).Returns(updatedPackageSent);

        var packageSentRequestEditDto = new PackageSentRequestDto
        {
            FoodList = _foodList, ReceiverId = Guid.NewGuid()
        };
        var result = await _service.Edit(packageSent.Id, packageSentRequestEditDto);

        var expectedResult = _mapper.Map<PackageSentResponseDto>(updatedPackageSent);
        result.Should().BeEquivalentTo(expectedResult);
    }
    
    [Fact]
    public async Task ShouldEditPackageSentFailed()
    {
        var packageSentId = Guid.NewGuid();
        var packageSent = new PackageSent(_foodList, Guid.NewGuid());

        _mock.Setup(r => r.FindAsync(packageSentId)).ReturnsAsync(packageSent);

        var ex = await Record.ExceptionAsync(async () => await _service.Edit(Guid.NewGuid(), new PackageSentRequestDto
        {
            FoodList = _foodList, ReceiverId = Guid.NewGuid()
        }));
            
        Assert.Equal($"No value found.", ex!.Message);
        Assert.Equal(typeof(ResourceNotFoundException), ex.GetType());
    }
    
    [Fact]
    public async Task ShouldDeletePackageSentSuccessfullyAsync()
    {
        var packageSentId = Guid.NewGuid();
        var packageSent = new PackageSent(_foodList, Guid.NewGuid());
        _mock.Setup(r => r.FindAsync(packageSentId)).ReturnsAsync(packageSent);

        await _service.Delete(packageSentId);
            
        _mock.Verify(m => m.DeleteAsync(packageSentId), Times.Once);
        _mock.Verify(m => m.SaveChangesAsync(), Times.Once);
    }
    
    [Fact]
    public async Task ShouldDeletePackageSentFailedAsync()
    {
        var packageSentId = Guid.NewGuid();
        PackageSent packageSent = null!;

        _mock.Setup(r => r.FindAsync(packageSentId)).ReturnsAsync(packageSent);
            
        var ex = await Record.ExceptionAsync(async () => await _service.Delete(packageSentId));
            
        Assert.Equal($"No value found.", ex!.Message);
        Assert.Equal(typeof(ResourceNotFoundException), ex.GetType());
            
        _mock.Verify(m => m.DeleteAsync(packageSentId), Times.Never);
        _mock.Verify(m => m.SaveChangesAsync(), Times.Never);
    }
}