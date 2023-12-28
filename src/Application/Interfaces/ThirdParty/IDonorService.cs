using Application.Dtos.ThirdPartyDtos;

namespace Application.Interfaces.ThirdParty;

public interface IDonorService
{
    Task<DonorResponseDto> Insert(DonorRequestDto dto);
    IEnumerable<DonorResponseDto> GetAll();
    Task<DonorResponseDto> GetById(Guid id);
    Task<DonorResponseDto> Edit(Guid id, DonorRequestDto dto);
    Task Delete(Guid id);
}