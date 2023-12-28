using Domain.Entities.ThirdPartyRegister;

namespace Application.Dtos.PackageDtos;

public class PackageReceivedRequestDto
{
    public List<Guid> FoodList { get; set; }
    public DateTime PackageCreation { get; set; }
    public Guid DonorId { get; set; }
}