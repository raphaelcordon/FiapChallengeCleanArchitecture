using Domain.Entities.ThirdPartyRegister;

namespace Application.Dtos.ThirdParty;

public class DonorResponseDto
{
    public Guid Id { get; set; }
    public required ThirdPartyName Name { get; set; }
    public bool IsCompany { get; set; }
}