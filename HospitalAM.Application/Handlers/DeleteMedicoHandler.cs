using HospitalAM.Application.Commands;
using HospitalAM.Core.Interfaces.Repository;
using MediatR;

namespace HospitalAM.Application.Handlers
{
    public class DeleteMedicoHandler : IRequestHandler<DeleteMedicoCommand, bool>
    {
        private readonly IMedicoRepository  _medicoRepository;

        public DeleteMedicoHandler(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        public async Task<bool> Handle(DeleteMedicoCommand request, CancellationToken cancellationToken)
        {
            return await  _medicoRepository.DeleteAsync(request.idMedico);
        }
    }
}
