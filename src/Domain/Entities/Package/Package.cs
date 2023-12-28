namespace Domain.Entities.Package;

public abstract class Package : Base
{
    protected Package(List<Guid> foodList)
    {
        FoodList = foodList ?? new List<Guid>();
        PackageCreation = DateTime.Now;
    }

    public List<Guid> FoodList { get; set; }
    public DateTime PackageCreation { get; private set; }
}