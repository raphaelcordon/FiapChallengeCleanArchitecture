namespace Domain.Entities.Package;

public class PackageSent : Package
{
    public PackageSent() : base(new List<Guid>())
    {
    }

    public PackageSent(List<Guid> foodList, Guid receiverId) : base(foodList)
    {
        ReceiverId = receiverId;
    }

    public Guid ReceiverId { get; set; }

    public void UpdateDetails(List<Guid> foodList, Guid receiverId)
    {
        FoodList = foodList;
        ReceiverId = receiverId;
    }
}