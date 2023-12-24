using System.Data;
using Application.Common;
using Application.Dtos.Food;
using Application.Interfaces.Food;
using AutoMapper;
using Domain.Entities.Food;
using Domain.Interfaces;
using static Application.Common.FoodExpirationDateValidator;

namespace Application.Services.FoodService;

public class FoodService : IFoodService
{
    private readonly IBaseRepository<Food> _repository;
    private readonly IMapper _mapper;

    public FoodService(IBaseRepository<Food> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<FoodResponseDto> Insert(FoodRequestDto dto)
    {
        if (IsDateExpired(dto.ExpirationDate))
            throw new DataException("Food expiration cannot be a past date or today");
        var food = _mapper.Map<Food>(dto);
        await _repository.AddAsync(food);
        await _repository.SaveChangesAsync();
        return _mapper.Map<FoodResponseDto>(food);
    }

    public IEnumerable<FoodResponseDto> GetAll()
    {
        var foods = _repository.List().ToArray();

        return _mapper.Map<IEnumerable<FoodResponseDto>>(foods);
    }

    public async Task<FoodResponseDto> GetById(Guid id)
    {
        var result = await _repository.FindAsync(id);
        if (result is null)
            throw new ResourceNotFoundException("No value found.");

        return _mapper.Map<FoodResponseDto>(result);
    }

    public async Task<FoodResponseDto> Edit(Guid id, FoodRequestDto dto)
    {
        if (IsDateExpired(dto.ExpirationDate))
            throw new DataException("Food expiration cannot be a past date or today");
        
        var result = await _repository.FindAsync(id);
        if (result is null)
            throw new ResourceNotFoundException("No value found.");
        
        result.UpdateDetails(dto.FoodName, dto.State, dto.IsPerishable, dto.ExpirationDate);
        var savedResult = _repository.Update(result);
        await _repository.SaveChangesAsync();

        return _mapper.Map<FoodResponseDto>(savedResult);
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