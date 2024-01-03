using Domain.Entities.ThirdPartyRegister;

namespace Presentation.Models.DonorModels;

public class DonorViewModel
{
    public ThirdPartyName? Name { get; set; }
    public bool IsCompany { get; set; }
}