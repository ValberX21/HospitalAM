using HospitalAM.Application.DTOs;
using HospitalAM.Application.ViewModel;
using MediatR;

namespace HospitalAM.Application.Queries
{
    public record GetAllMedicosQuery(int Page = 1, int PageSize = 5) : IRequest<PagedResult<MedicoListItemViewModel>>;
}
