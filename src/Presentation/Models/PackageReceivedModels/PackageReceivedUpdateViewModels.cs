using Application.Dtos.FoodDtos;
using Application.Dtos.PackageDtos;
using Application.Dtos.ThirdPartyDtos;

namespace Presentation.Models.PackageReceivedModels;

public class PackageReceivedUpdateViewModels
{
    public PackageReceivedResponseDto? Package { get; set; }
    public IEnumerable<DonorResponseDto>? Donors { get; set; }
    public IEnumerable<FoodResponseDto>? Foods { get; set; }
}