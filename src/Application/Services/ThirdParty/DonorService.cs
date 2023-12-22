using Application.Dtos.ThirdParty;
using Application.Interfaces.ThirdParty;
using AutoMapper;
using Domain.Entities.ThirdPartyRegister;
using Domain.Interfaces;

namespace Application.Services.ThirdParty;

public class DonorService : IDonorService
{
    private readonly IBaseRepository<Donor> _repository;
    private readonly IMapper _mapper;

    public DonorService(IBaseRepository<Donor> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<DonorResponseDto> Insert(DonorRequestDto dto)
    {
        var donor = _mapper.Map<Donor>(dto);
        await _repository.AddAsync(donor);
        await _repository.SaveChangesAsync();
        return _mapper.Map<DonorResponseDto>(donor);
    }

    public IEnumerable<DonorResponseDto> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<DonorResponseDto> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<DonorResponseDto> Edit(Guid id, DonorRequestDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<DonorResponseDto> Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}