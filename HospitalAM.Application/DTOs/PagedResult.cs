using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAM.Application.DTOs
{
    public record PagedResult<T>(
        IReadOnlyList<T> Items,
        int TotalItems,
        int Page,
        int PageSize
        )
    {
        public int TotalPages => Math.Max(1, (int)Math.Ceiling((double)TotalItems / PageSize));
        public bool HasPrevious => Page > 1;
        public bool HasNext => Page < TotalPages;
    }
}
