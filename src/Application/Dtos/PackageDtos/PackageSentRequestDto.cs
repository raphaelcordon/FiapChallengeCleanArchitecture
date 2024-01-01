namespace Application.Dtos.PackageDtos;

public class PackageSentRequestDto
{
    public List<Guid> FoodList { get; set; }
    public DateTime PackageCreation { get; } = DateTime.Now;
    public Guid ReceiverId { get; set; }
}