namespace Application.Dtos.PackageDtos;

public class PackageReceivedRequestDto
{
    public List<Guid> FoodList { get; set; }
    public DateTime PackageCreation { get; } = DateTime.Now;
    public Guid DonorId { get; set; }
}