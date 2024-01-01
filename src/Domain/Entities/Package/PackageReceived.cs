namespace Domain.Entities.Package;

public class PackageReceived : Package
{
    public PackageReceived() : base(new List<Guid>())
    {
    }

    public PackageReceived(List<Guid> foodList, Guid donorId) : base(foodList)
    {
        DonorId = donorId;
    }

    public Guid DonorId { get; set; }

    public void UpdateDetails(List<Guid> foodList, Guid donorId)
    {
        FoodList = foodList;
        DonorId = donorId;
    }
}