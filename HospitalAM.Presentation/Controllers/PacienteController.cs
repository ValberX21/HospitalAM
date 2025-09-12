using HospitalAM.Application.Queries;
using HospitalAM.Application.ViewModel;
using HospitalAM.Presentation.Helper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAM.Presentation.Controllers
{
    public class PacienteController : Controller
    {
        private readonly IMediator _mediator;
        private readonly GetDrops _getDrops;

        public PacienteController(IMediator mediator, GetDrops getDrops)
        {
            _mediator = mediator;
            _getDrops = new GetDrops(_mediator);
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 5, int pageSize = 10)
        {
            var paged = await _mediator.Send(new GetAllPacientesQuery(page, pageSize));
            
            var vm = new PacienteViewModel
            {
                PageNumber = page,
                PageSize = paged.PageSize,
                TotalCount = paged.TotalItems,
                TotalPages = paged.TotalPages,
                Pacientes = paged.Items
            };


            
            vm.Empresas = await _getDrops.GetEmpresas();
            return View(vm);
        }
    }
}
