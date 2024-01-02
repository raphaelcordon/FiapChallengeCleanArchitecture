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

public class TestReceiver
{
    private readonly Mock<IBaseRepository<Receiver>> _mock;
    private readonly IMapper _mapper;
    private readonly ReceiverService _service;

    public TestReceiver()
    {
        _mock = new Mock<IBaseRepository<Receiver>>();
        _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperConfig())));
        _service = new ReceiverService(_mock.Object, _mapper);
    }

    [Fact]
    public async Task ShouldCreateReceiverSuccessfullyAsync()
    {
        var receiverName = new ThirdPartyName("TestReceiver");
        var dto = new ReceiverRequestDto { Name = receiverName, IsCompany = true };

        var result = await _service.Insert(dto);

        var expectedResult = _mapper.Map<Receiver>(dto);
        
        _mock.Verify(m => m.AddAsync(It.IsAny<Receiver>()), Times.Once);
        _mock.Verify(m => m.SaveChangesAsync(), Times.Once);

        result.Should().BeEquivalentTo(expectedResult, opt => 
            opt.Excluding(x => x.Id));
    }

    [Fact]
    public async Task ShouldGetReceiverByIdSuccessfullyAsync()
    {
        var receiverName = new ThirdPartyName("TestReceiver");
        var receiver = new Receiver { IsCompany = true, Name = receiverName};

        _mock.Setup(r => r.FindAsync(receiver.Id)).ReturnsAsync(receiver);

        var result = await _service.GetById(receiver.Id);

        var expectedResult = _mapper.Map<ReceiverResponseDto>(receiver);
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public async Task ShouldGetAllReceiversSucessfullyAsync()
    {
        var receiverName = new ThirdPartyName("TestReceiver");
        var receivers = new List<Receiver>
        {
            new Receiver { IsCompany = true, Name = receiverName },
            new Receiver { IsCompany = false, Name = receiverName }
        };

        _mock.Setup(r => r.List()).Returns(receivers);

        var result = _service.GetAll();

        var expectedResult = _mapper.Map<IEnumerable<ReceiverResponseDto>>(receivers);
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public async Task ShouldEditReceiverSuccessfullyAsync()
    {
        var receiverName = new ThirdPartyName("TestReceiver");
        var receiver = new Receiver { Name = receiverName, IsCompany = true };
        var updatedReceiver = new Receiver { Name = receiverName, IsCompany = false };

        _mock.Setup(r => r.FindAsync(receiver.Id)).ReturnsAsync(receiver);
        _mock.Setup(r => r.Update(receiver)).Returns(updatedReceiver);

        var receiverRequestEditDto = new ReceiverRequestDto
        {
            Name = updatedReceiver.Name, IsCompany = updatedReceiver.IsCompany
        };
        var result = await _service.Edit(receiver.Id, receiverRequestEditDto);

        var expectedResult = _mapper.Map<ReceiverResponseDto>(updatedReceiver);
        result.Should().BeEquivalentTo(expectedResult);
    }
    
    [Fact]
    public async Task ShouldEditReceiverFailed()
    {
        var receiverId = Guid.NewGuid();
        var receiverName = new ThirdPartyName("TestReceiver");
        var receiver = new Receiver { Name = receiverName, IsCompany = true };

        _mock.Setup(r => r.FindAsync(receiverId)).ReturnsAsync(receiver);

        var ex = await Record.ExceptionAsync(async () => await _service.Edit(Guid.NewGuid(), new ReceiverRequestDto
        {
            Name = new ThirdPartyName(""), IsCompany = false
        }));
            
        Assert.Equal($"No value found.", ex.Message);
        Assert.Equal(typeof(ResourceNotFoundException), ex.GetType());
    }
    
    [Fact]
    public async Task ShouldDeleteReceiverSuccessfullyAsync()
    {
        var receiverId = Guid.NewGuid();
        _mock.Setup(r => r.FindAsync(receiverId)).ReturnsAsync(new Receiver());

        await _service.Delete(receiverId);
            
        _mock.Verify(m => m.DeleteAsync(receiverId), Times.Once);
        _mock.Verify(m => m.SaveChangesAsync(), Times.Once);
    }
    
    [Fact]
    public async Task ShouldDeleteReceiverFailedAsync()
    {
        var receiverId = Guid.NewGuid();
        Receiver receiver = null;

        _mock.Setup(r => r.FindAsync(receiverId)).ReturnsAsync(receiver);
            
        var ex = await Record.ExceptionAsync(async () => await _service.Delete(receiverId));
            
        Assert.Equal($"No value found.", ex.Message);
        Assert.Equal(typeof(ResourceNotFoundException), ex.GetType());
            
        _mock.Verify(m => m.DeleteAsync(receiverId), Times.Never);
        _mock.Verify(m => m.SaveChangesAsync(), Times.Never);
    }
}