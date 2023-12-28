using Domain.Entities.ThirdPartyRegister;

namespace Application.Dtos.ThirdPartyDtos;

public class ReceiverResponseDto
{
    public Guid Id { get; set; }
    public required ThirdPartyName Name { get; set; }
    public bool IsCompany { get; set; }
}