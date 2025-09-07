using HospitalAM.Application.DTOs;
using HospitalAM.Application.Queries;
using HospitalAM.Core.Entities;
using HospitalAM.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;

namespace HospitalAM.Application.Handlers
{
    public class GetAllHospitaisHandler : IRequestHandler<GetAllHospitaisQuery, List<Hospital>>
    {
        private readonly IBaseCRUDRepository<Hospital> _hospitalRepository;
       
        public GetAllHospitaisHandler(IBaseCRUDRepository<Hospital> hospitalRepository)
        {
            _hospitalRepository = hospitalRepository;
        }

        public async Task<List<Hospital>> Handle(GetAllHospitaisQuery request, CancellationToken cancellationToken)
        {
            List<Hospital> hospitaisList =  new List<Hospital>();

            if (request.hospitalId > 0)
            {
                Hospital? hospital = await _hospitalRepository.GetByIDAsync(request.hospitalId.Value, cancellationToken);
                if(hospital != null)
                    hospitaisList.Add(hospital);
            }
            else
            {
                var hospitais = await _hospitalRepository.GeAll(cancellationToken);
                if (hospitais != null)
                    hospitaisList = hospitais.ToList(); 
            }
            return hospitaisList;
        }
    }
}
