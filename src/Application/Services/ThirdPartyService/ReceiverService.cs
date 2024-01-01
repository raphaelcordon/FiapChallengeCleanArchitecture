using Application.Common;
using Application.Dtos.ThirdPartyDtos;
using Application.Interfaces.ThirdParty;
using AutoMapper;
using Domain.Entities.ThirdPartyRegister;
using Domain.Interfaces;

namespace Application.Services.ThirdPartyService;

public class ReceiverService : IReceiverService
{
    private readonly IMapper _mapper;
    private readonly IBaseRepository<Receiver> _repository;

    public ReceiverService(IBaseRepository<Receiver> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ReceiverResponseDto> Insert(ReceiverRequestDto dto)
    {
        var receiver = _mapper.Map<Receiver>(dto);
        await _repository.AddAsync(receiver);
        await _repository.SaveChangesAsync();
        return _mapper.Map<ReceiverResponseDto>(receiver);
    }

    public IEnumerable<ReceiverResponseDto> GetAll()
    {
        var receivers = _repository.List().ToArray();

        return _mapper.Map<IEnumerable<ReceiverResponseDto>>(receivers);
    }

    public async Task<ReceiverResponseDto> GetById(Guid id)
    {
        var result = await _repository.FindAsync(id);
        if (result is null)
            throw new ResourceNotFoundException("No value found.");

        return _mapper.Map<ReceiverResponseDto>(result);
    }

    public async Task<ReceiverResponseDto> Edit(Guid id, ReceiverRequestDto dto)
    {
        var result = await _repository.FindAsync(id);
        if (result is null)
            throw new ResourceNotFoundException("No value found.");

        result.UpdateDetails(dto.Name, dto.IsCompany);
        var savedResult = _repository.Update(result);
        await _repository.SaveChangesAsync();

        return _mapper.Map<ReceiverResponseDto>(savedResult);
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