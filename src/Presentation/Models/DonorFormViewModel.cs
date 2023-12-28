using Application.Dtos.ThirdPartyDtos;

namespace Presentation.Models;

public class DonorFormViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsCompany { get; set; }
}