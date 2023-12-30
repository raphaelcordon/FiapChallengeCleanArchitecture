using Domain.Entities.ThirdPartyRegister;

namespace Application.Dtos.PackageDtos;

public class PackageSentResponseDto
{
    public Guid Id { get; set; }
    public List<Guid> FoodList { get; set; }
    public DateTime PackageCreation { get; private set; }
    public Guid ReceiverId { get; set; }
}