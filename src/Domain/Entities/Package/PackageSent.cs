using Domain.Entities.ThirdPartyRegister;

namespace Domain.Entities.Package;

public class PackageSent : Package
{
    public PackageSent(List<Food.Food> foodList, Receiver receiver) : base(foodList)
    {
        Receiver = receiver;
    }
    public Receiver Receiver { get; set; }
}