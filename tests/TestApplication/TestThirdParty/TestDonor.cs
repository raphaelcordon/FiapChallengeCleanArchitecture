using Application.Common;
using Application.Dtos.ThirdPartyDtos;
using Application.Services.ThirdPartyService;
using AutoMapper;
using FluentAssertions;
using Domain.Entities.ThirdPartyRegister;
using Domain.Interfaces;
using Moq;
using Xunit;

namespace TestApplication.TestThirdParty;

public class TestDonor
{
    private readonly Mock<IBaseRepository<Donor>> _mock;
    private readonly IMapper _mapper;
    private readonly DonorService _service;

    public TestDonor()
    {
        _mock = new Mock<IBaseRepository<Donor>>();
        _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperConfig())));
        _service = new DonorService(_mock.Object, _mapper);
    }

    [Fact]
    public async Task ShouldCreateDonorSuccessfullyAsync()
    {
        var donorName = new ThirdPartyName("TestDonor");
        var dto = new DonorRequestDto { Name = donorName, IsCompany = true };

        var result = await _service.Insert(dto);

        var expectedResult = _mapper.Map<Donor>(dto);
        
        _mock.Verify(m => m.AddAsync(It.IsAny<Donor>()), Times.Once);
        _mock.Verify(m => m.SaveChangesAsync(), Times.Once);

        result.Should().BeEquivalentTo(expectedResult, opt => 
            opt.Excluding(x => x.Id));
    }

    [Fact]
    public async Task ShouldGetDonorByIdSuccessfullyAsync()
    {
        var donorName = new ThirdPartyName("TestDonor");
        var donor = new Donor { IsCompany = true, Name = donorName};

        _mock.Setup(r => r.FindAsync(donor.Id)).ReturnsAsync(donor);

        var result = await _service.GetById(donor.Id);

        var expectedResult = _mapper.Map<DonorResponseDto>(donor);
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public Task ShouldGetAllDonorsSuccessfullyAsync()
    {
        var donorName = new ThirdPartyName("TestDonor");
        var donors = new List<Donor>
        {
            new Donor { IsCompany = true, Name = donorName },
            new Donor { IsCompany = false, Name = donorName }
        };

        _mock.Setup(r => r.List()).Returns(donors);

        var result = _service.GetAll();

        var expectedResult = _mapper.Map<IEnumerable<DonorResponseDto>>(donors);
        result.Should().BeEquivalentTo(expectedResult);
        return Task.CompletedTask;
    }

    [Fact]
    public async Task ShouldEditDonorSuccessfullyAsync()
    {
        var donorName = new ThirdPartyName("TestDonor");
        var donor = new Donor { Name = donorName, IsCompany = true };
        var updatedDonor = new Donor { Name = donorName, IsCompany = false };

        _mock.Setup(r => r.FindAsync(donor.Id)).ReturnsAsync(donor);
        _mock.Setup(r => r.Update(donor)).Returns(updatedDonor);

        var donorRequestEditDto = new DonorRequestDto
        {
            Name = updatedDonor.Name, IsCompany = updatedDonor.IsCompany
        };
        var result = await _service.Edit(donor.Id, donorRequestEditDto);

        var expectedResult = _mapper.Map<DonorResponseDto>(updatedDonor);
        result.Should().BeEquivalentTo(expectedResult);
    }
    
    [Fact]
    public async Task ShouldEditDonorFailed()
    {
        var donorId = Guid.NewGuid();
        var donorName = new ThirdPartyName("TestDonor");
        var donor = new Donor { Name = donorName, IsCompany = true };

        _mock.Setup(r => r.FindAsync(donorId)).ReturnsAsync(donor);

        var ex = await Record.ExceptionAsync(async () => await _service.Edit(Guid.NewGuid(), new DonorRequestDto
        {
            Name = new ThirdPartyName(""), IsCompany = false
        }));
            
        Assert.Equal($"No value found.", ex!.Message);
        Assert.Equal(typeof(ResourceNotFoundException), ex.GetType());
    }
    
    [Fact]
    public async Task ShouldDeleteDonorSuccessfullyAsync()
    {
        var donorId = Guid.NewGuid();
        _mock.Setup(r => r.FindAsync(donorId)).ReturnsAsync(new Donor());

        await _service.Delete(donorId);
            
        _mock.Verify(m => m.DeleteAsync(donorId), Times.Once);
        _mock.Verify(m => m.SaveChangesAsync(), Times.Once);
    }
    
    [Fact]
    public async Task ShouldDeleteDonorFailedAsync()
    {
        var donorId = Guid.NewGuid();
        Donor donor = null!;

        _mock.Setup(r => r.FindAsync(donorId)).ReturnsAsync(donor);
            
        var ex = await Record.ExceptionAsync(async () => await _service.Delete(donorId));
            
        Assert.Equal($"No value found.", ex!.Message);
        Assert.Equal(typeof(ResourceNotFoundException), ex.GetType());
            
        _mock.Verify(m => m.DeleteAsync(donorId), Times.Never);
        _mock.Verify(m => m.SaveChangesAsync(), Times.Never);
    }
}