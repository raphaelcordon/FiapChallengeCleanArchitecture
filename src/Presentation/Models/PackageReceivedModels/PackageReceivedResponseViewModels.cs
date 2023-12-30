namespace Presentation.Models.PackageReceivedModels;

public class PackageReceivedResponseViewModels
{
    public Guid Id { get; set; }
    public Guid DonorId { get; set; }
    public List<Guid> SelectedFoods { get; set; } = new List<Guid>();
}