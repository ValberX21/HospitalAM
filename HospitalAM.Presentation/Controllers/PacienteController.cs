using HospitalAM.Application.Commands;
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

        [HttpGet]
        public async Task<IActionResult> goToCreate()
        {
            var vm = new PacienteViewModel
            {
                Ativo = true,
                Empresas = await _getDrops.GetEmpresas()
            };

            return View("CreateEditPaciente", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PacienteViewModel vm, CancellationToken ct)
        {
            if (!ModelState.IsValid)
            {
                vm.Empresas = await _getDrops.GetHospitaisSelectAsync(vm.IdEmpresa);
                return View("CreateEditMedico", vm);
            }

            var command = CreatePacienteCommand.FromViewModel(vm);
            var id = await _mediator.Send(command, ct);

            TempData["Success"] = "Médico criado com sucesso.";

            return RedirectToAction(nameof(Index));
        }

        //[HttpPut]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit([FromBody] PacienteViewModel vm, CancellationToken ct)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        vm.Empresas = await _getDrops.GetHospitaisSelectAsync(vm.IdEmpresa);
        //        return View("CreateEditPaciente", vm);
        //    }

        //    var command = CreatePacienteCommand.FromViewModel(vm);
        //    var id = await _mediator.Send(command, ct);

        //    // TODO: map + save
        //    TempData["Success"] = "Médico criado com sucesso.";

        //    return View("Index", vm);
        //}

    }
}
