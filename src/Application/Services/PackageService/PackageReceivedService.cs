using Application.Common;
using Application.Dtos.PackageDtos;
using Application.Interfaces.Package;
using AutoMapper;
using Domain.Entities.Package;
using Domain.Interfaces;

namespace Application.Services.PackageService;

public class PackageReceivedService : IPackageReceivedService
{
    private readonly IMapper _mapper;
    private readonly IBaseRepository<PackageReceived> _repository;

    public PackageReceivedService(IBaseRepository<PackageReceived> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PackageReceivedResponseDto> Insert(PackageReceivedRequestDto dto)
    {
        var packageReceived = _mapper.Map<PackageReceived>(dto);
        await _repository.AddAsync(packageReceived);
        await _repository.SaveChangesAsync();
        return _mapper.Map<PackageReceivedResponseDto>(packageReceived);
    }

    public IEnumerable<PackageReceivedResponseDto> GetAll()
    {
        var packageReceiveds = _repository.List().ToArray();

        return _mapper.Map<IEnumerable<PackageReceivedResponseDto>>(packageReceiveds);
    }

    public async Task<PackageReceivedResponseDto> GetById(Guid id)
    {
        var result = await _repository.FindAsync(id);
        if (result is null)
            throw new ResourceNotFoundException("No value found.");

        return _mapper.Map<PackageReceivedResponseDto>(result);
    }

    public async Task<PackageReceivedResponseDto> Edit(Guid id, PackageReceivedRequestDto dto)
    {
        var result = await _repository.FindAsync(id);
        if (result is null)
            throw new ResourceNotFoundException("No value found.");

        result.UpdateDetails(dto.FoodList, dto.DonorId);
        var savedResult = _repository.Update(result);
        await _repository.SaveChangesAsync();

        return _mapper.Map<PackageReceivedResponseDto>(savedResult);
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