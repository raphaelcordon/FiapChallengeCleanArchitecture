using Domain.Entities.ThirdPartyRegister;

namespace Application.Dtos.PackageDtos;

public class PackageReceivedResponseDto
{
    public Guid Id { get; set; }
    public List<Guid> FoodList { get; set; }
    public DateTime PackageCreation { get; private set; }
    public Guid DonorId { get; set; }
}