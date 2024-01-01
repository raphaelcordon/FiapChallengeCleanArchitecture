namespace Presentation.Models.PackageSentModels;

public class PackageSentResponseViewModels
{
    public Guid Id { get; set; }
    public Guid ReceiverId { get; set; }
    public List<Guid> SelectedFoods { get; set; } = new();
}