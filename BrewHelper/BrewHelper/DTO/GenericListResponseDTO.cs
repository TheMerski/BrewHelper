using System.Collections.Generic;

namespace BrewHelper.DTO
{
    public record GenericListResponseDTO<T>
    {
        public GenericListResponseDTO()
        {
            Items = new List<T>();
        }

        public int CurrentPage { get; init; }

        public int TotalItems { get; init; }

        public int TotalPages { get; init; }

        public List<T> Items { get; init; }
    }
}
