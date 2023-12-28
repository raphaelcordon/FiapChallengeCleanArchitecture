namespace Domain.Entities.Package;

public class PackageSentFood
{
    public Guid PackageSentId { get; set; }
    public PackageSent PackageSent { get; set; }

    public Guid FoodId { get; set; }
    public Food.Food Food { get; set; }
}