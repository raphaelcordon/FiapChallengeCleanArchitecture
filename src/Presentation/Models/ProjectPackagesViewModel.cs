using Application.Dtos.FoodDtos;
using Application.Dtos.PackageDtos;
using Application.Dtos.ThirdPartyDtos;

namespace Presentation.Models;

public class ProjectPackagesViewModel
{
    public IEnumerable<DonorResponseDto>? Donors { get; set; }
    public IEnumerable<ReceiverResponseDto>? Receivers { get; set; }
    public IEnumerable<FoodResponseDto>? Foods { get; set; }
    public IEnumerable<PackageReceivedResponseDto>? PackagesReceived { get; set; }
    public IEnumerable<PackageSentResponseDto>? PackagesSent { get; set; }
}