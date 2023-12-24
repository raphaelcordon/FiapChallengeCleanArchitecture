using Application.Common;
using Application.Dtos.ThirdParty;
using Application.Interfaces.ThirdParty;
using AutoMapper;
using Domain.Entities.ThirdPartyRegister;
using Domain.Interfaces;

namespace Application.Services.ThirdPartyService;

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
        var donors = _repository.List().ToArray();

        return _mapper.Map<IEnumerable<DonorResponseDto>>(donors);
    }

    public async Task<DonorResponseDto> GetById(Guid id)
    {
        var result = await _repository.FindAsync(id);
        if (result is null)
            throw new ResourceNotFoundException("No value found.");

        return _mapper.Map<DonorResponseDto>(result);
    }

    public async Task<DonorResponseDto> Edit(Guid id, DonorRequestDto dto)
    {
        var result = await _repository.FindAsync(id);
        if (result is null)
            throw new ResourceNotFoundException("No value found.");
        
        result.UpdateDetails(dto.Name, dto.IsCompany);
        var savedResult = _repository.Update(result);
        await _repository.SaveChangesAsync();

        return _mapper.Map<DonorResponseDto>(savedResult);
    }

    public async Task Delete(Guid id)
    {
        var result = await _repository.FindAsync(id);
        if (result is null)
            throw new ResourceNotFoundException("No value found.");
        
        await _repository.DeleteAsync(id);
        await _repository.SaveChangesAsync();
    }
}