using Application.Common;
using Application.Dtos.PackageDtos;
using Application.Interfaces.Package;
using AutoMapper;
using Domain.Entities.Package;
using Domain.Interfaces;

namespace Application.Services.PackageService;

public class PackageSentService : IPackageSentService
{
    private readonly IMapper _mapper;
    private readonly IBaseRepository<PackageSent> _repository;

    public PackageSentService(IBaseRepository<PackageSent> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PackageSentResponseDto> Insert(PackageSentRequestDto dto)
    {
        var packageSent = _mapper.Map<PackageSent>(dto);
        await _repository.AddAsync(packageSent);
        await _repository.SaveChangesAsync();
        return _mapper.Map<PackageSentResponseDto>(packageSent);
    }

    public IEnumerable<PackageSentResponseDto> GetAll()
    {
        var packageSents = _repository.List().ToArray();

        return _mapper.Map<IEnumerable<PackageSentResponseDto>>(packageSents);
    }

    public async Task<PackageSentResponseDto> GetById(Guid id)
    {
        var result = await _repository.FindAsync(id);
        if (result is null)
            throw new ResourceNotFoundException("No value found.");

        return _mapper.Map<PackageSentResponseDto>(result);
    }

    public async Task<PackageSentResponseDto> Edit(Guid id, PackageSentRequestDto dto)
    {
        var result = await _repository.FindAsync(id);
        if (result is null)
            throw new ResourceNotFoundException("No value found.");

        result.UpdateDetails(dto.FoodList, dto.ReceiverId);
        var savedResult = _repository.Update(result);
        await _repository.SaveChangesAsync();

        return _mapper.Map<PackageSentResponseDto>(savedResult);
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