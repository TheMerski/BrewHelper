using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrewHelper.DTO
{
    public record GenericListResponseDTO<T>
    {
        public int CurrentPage { get; init; }

        public int TotalItems { get; init; }

        public int TotalPages { get; init; }

        public List<T> Items { get; init; }
    }
}
