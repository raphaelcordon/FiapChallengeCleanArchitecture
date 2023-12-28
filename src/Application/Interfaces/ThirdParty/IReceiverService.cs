using Application.Dtos.ThirdPartyDtos;

namespace Application.Interfaces.ThirdParty;

public interface IReceiverService
{
    Task<ReceiverResponseDto> Insert(ReceiverRequestDto dto);
    IEnumerable<ReceiverResponseDto> GetAll();
    Task<ReceiverResponseDto> GetById(Guid id);
    Task<ReceiverResponseDto> Edit(Guid id, ReceiverRequestDto dto);
    Task Delete(Guid id);
}