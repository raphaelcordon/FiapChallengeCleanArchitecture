using Domain.Entities.ThirdPartyRegister;

namespace Application.Dtos.PackageDtos;

public class PackageSentRequestDto
{
    public List<Guid> FoodList { get; set; }
    public DateTime PackageCreation { get; set; }
    public Guid ReceiverId { get; set; }
}