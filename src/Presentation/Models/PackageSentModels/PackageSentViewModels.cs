using Application.Dtos.FoodDtos;
using Application.Dtos.PackageDtos;
using Application.Dtos.ThirdPartyDtos;

namespace Presentation.Models.PackageSentModels;

public class PackageSentViewModels
{
    public IEnumerable<PackageSentResponseDto>? Packages { get; set; }
    public IEnumerable<ReceiverResponseDto>? Receivers { get; set; }
    public IEnumerable<FoodResponseDto>? Foods { get; set; }
}