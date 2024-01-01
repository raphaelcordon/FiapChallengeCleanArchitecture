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
}