using Domain.Entities.ThirdPartyRegister;

namespace Domain.Entities.Package;

public class PackageReceived : Package
{
    public PackageReceived(List<Food.Food> foodList, Donor donor) : base(foodList)
    {
        Donor = donor;
    }
    
    public Donor Donor { get; set; }
}