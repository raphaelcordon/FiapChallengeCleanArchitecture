using Application.Dtos.PackageDtos;

namespace Application.Interfaces.Package;

public interface IPackageSentService
{
    Task<PackageSentResponseDto> Insert(PackageSentRequestDto dto);
    IEnumerable<PackageSentResponseDto> GetAll();
    Task<PackageSentResponseDto> GetById(Guid id);
    Task<PackageSentResponseDto> Edit(Guid id, PackageSentRequestDto dto);
    Task Delete(Guid id);
}