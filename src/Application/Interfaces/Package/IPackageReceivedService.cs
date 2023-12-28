using Application.Dtos.PackageDtos;

namespace Application.Interfaces.Package;

public interface IPackageReceivedService
{
    Task<PackageReceivedResponseDto> Insert(PackageReceivedRequestDto dto);
    IEnumerable<PackageReceivedResponseDto> GetAll();
    Task<PackageReceivedResponseDto> GetById(Guid id);
    Task<PackageReceivedResponseDto> Edit(Guid id, PackageReceivedRequestDto dto);
    Task Delete(Guid id);
}