using Domain.Enums.Food;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Presentation.Models;

public class StateViewModel
{
    public int SelectedState { get; set; }
    public List <SelectListItem> States { get; set; }
}