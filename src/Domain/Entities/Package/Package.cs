namespace Domain.Entities.Package;

public abstract class Package : Base
{
    protected Package(List<Food.Food> foodList)
    {
        FoodList = foodList;
        PackageCreation = DateTime.Now;
    }

    public List<Food.Food> FoodList { get; set; }
    public DateTime PackageCreation { get; private set; }
}