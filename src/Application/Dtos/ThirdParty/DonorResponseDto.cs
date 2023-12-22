using Domain.Entities.ThirdPartyRegister;

namespace Application.Dtos.ThirdParty;

public class DonorResponseDto
{
    public required ThirdPartyName Name { get; set; }
    public bool IsCompany { get; set; }
}