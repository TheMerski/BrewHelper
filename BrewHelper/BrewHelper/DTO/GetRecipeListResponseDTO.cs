using BrewHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrewHelper.DTO
{
    public record GetRecipeListResponseDTO
    {
        public int CurrentPage { get; init; }

        public int TotalItems { get; init; }

        public int TotalPages { get; init; }

        public List<RecipeDTO> Items { get; init; }
    }
}
