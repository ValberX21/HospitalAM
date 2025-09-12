using HospitalAM.Application.DTOs;
using HospitalAM.Application.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAM.Application.Queries
{
    public record GetAllPacientesQuery(int Page = 1, int PageSize = 5) : IRequest<PagedResult<PacienteListItemViewModel>>;
}
