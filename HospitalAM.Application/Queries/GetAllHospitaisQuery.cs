using HospitalAM.Application.DTOs;
using HospitalAM.Core.Entities;
using MediatR;

namespace HospitalAM.Application.Queries
{
    public record GetAllHospitaisQuery(int? hospitalId) : IRequest<List<Hospital>>
    {
    }
}
