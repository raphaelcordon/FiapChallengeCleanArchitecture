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

public class TestPackageReceived
{
    private readonly Mock<IBaseRepository<PackageReceived>> _mock;
    private readonly IMapper _mapper;
    private readonly PackageReceivedService _service;

    public TestPackageReceived()
    {
        _mock = new Mock<IBaseRepository<PackageReceived>>();
        _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperConfig())));
        _service = new PackageReceivedService(_mock.Object, _mapper);
    }
    
    private readonly List<Guid> _foodList = new List<Guid>{ Guid.NewGuid(), Guid.NewGuid() };

    [Fact]
    public async Task ShouldCreatePackageReceivedSuccessfullyAsync()
    {
        var dto = new PackageReceivedRequestDto { FoodList = _foodList, DonorId = Guid.NewGuid()};

        var result = await _service.Insert(dto);

        var expectedResult = _mapper.Map<PackageReceived>(dto);
        
        _mock.Verify(m => m.AddAsync(It.IsAny<PackageReceived>()), Times.Once);
        _mock.Verify(m => m.SaveChangesAsync(), Times.Once);

        result.Should().BeEquivalentTo(expectedResult, opt => 
            opt.Excluding(x => x.Id));
    }

    [Fact]
    public async Task ShouldGetPackageReceivedByIdSuccessfullyAsync()
    {
        var packageReceived = new PackageReceived(_foodList, Guid.NewGuid());

        _mock.Setup(r => r.FindAsync(packageReceived.Id)).ReturnsAsync(packageReceived);

        var result = await _service.GetById(packageReceived.Id);

        var expectedResult = _mapper.Map<PackageReceivedResponseDto>(packageReceived);
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public Task ShouldGetAllPackageReceivedSuccessfullyAsync()
    {
        var packagesReceived = new List<PackageReceived>
        {
            new PackageReceived(_foodList, Guid.NewGuid()),
            new PackageReceived(_foodList, Guid.NewGuid())
        };

        _mock.Setup(r => r.List()).Returns(packagesReceived);

        var result = _service.GetAll();

        var expectedResult = _mapper.Map<IEnumerable<PackageReceivedResponseDto>>(packagesReceived);
        result.Should().BeEquivalentTo(expectedResult);
        return Task.CompletedTask;
    }

    [Fact]
    public async Task ShouldEditPackageReceivedSuccessfullyAsync()
    {
        var packageReceived = new PackageReceived(_foodList, Guid.NewGuid());
        var updatedPackageReceived = new PackageReceived(_foodList, Guid.NewGuid());

        _mock.Setup(r => r.FindAsync(packageReceived.Id)).ReturnsAsync(packageReceived);
        _mock.Setup(r => r.Update(packageReceived)).Returns(updatedPackageReceived);

        var packageReceivedRequestEditDto = new PackageReceivedRequestDto
        {
            FoodList = _foodList, DonorId = Guid.NewGuid()
        };
        var result = await _service.Edit(packageReceived.Id, packageReceivedRequestEditDto);

        var expectedResult = _mapper.Map<PackageReceivedResponseDto>(updatedPackageReceived);
        result.Should().BeEquivalentTo(expectedResult);
    }
    
    [Fact]
    public async Task ShouldEditPackageReceivedFailed()
    {
        var packageReceivedId = Guid.NewGuid();
        var packageReceived = new PackageReceived(_foodList, Guid.NewGuid());

        _mock.Setup(r => r.FindAsync(packageReceivedId)).ReturnsAsync(packageReceived);

        var ex = await Record.ExceptionAsync(async () => await _service.Edit(Guid.NewGuid(), new PackageReceivedRequestDto
        {
            FoodList = _foodList, DonorId = Guid.NewGuid()
        }));
            
        Assert.Equal($"No value found.", ex!.Message);
        Assert.Equal(typeof(ResourceNotFoundException), ex.GetType());
    }
    
    [Fact]
    public async Task ShouldDeletePackageReceivedSuccessfullyAsync()
    {
        var packageReceivedId = Guid.NewGuid();
        var packageReceived = new PackageReceived(_foodList, Guid.NewGuid());
        _mock.Setup(r => r.FindAsync(packageReceivedId)).ReturnsAsync(packageReceived);

        await _service.Delete(packageReceivedId);
            
        _mock.Verify(m => m.DeleteAsync(packageReceivedId), Times.Once);
        _mock.Verify(m => m.SaveChangesAsync(), Times.Once);
    }
    
    [Fact]
    public async Task ShouldDeletePackageReceivedFailedAsync()
    {
        var packageReceivedId = Guid.NewGuid();
        PackageReceived packageReceived = null!;

        _mock.Setup(r => r.FindAsync(packageReceivedId)).ReturnsAsync(packageReceived);
            
        var ex = await Record.ExceptionAsync(async () => await _service.Delete(packageReceivedId));
            
        Assert.Equal($"No value found.", ex!.Message);
        Assert.Equal(typeof(ResourceNotFoundException), ex.GetType());
            
        _mock.Verify(m => m.DeleteAsync(packageReceivedId), Times.Never);
        _mock.Verify(m => m.SaveChangesAsync(), Times.Never);
    }
}