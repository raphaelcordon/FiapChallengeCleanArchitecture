namespace Domain.Entities.Package;

public class PackageReceivedFood
{
    public Guid PackageReceivedId { get; set; }
    public PackageReceived PackageReceived { get; set; }

    public Guid FoodId { get; set; }
    public Food.Food Food { get; set; }
}