using HospitalAM.Application.Commands;
using HospitalAM.Application.DTOs;
using HospitalAM.Application.Handlers;
using HospitalAM.Application.Queries;
using HospitalAM.Application.ViewModel;
using HospitalAM.Core.Entities;
using HospitalAM.Presentation.Helper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospitalAM.Presentation.Controllers
{
    public class MedicoController : Controller
    {
        private readonly IMediator _mediator;
        private readonly GetDrops _getDrops;

        public MedicoController(IMediator mediator, GetDrops getDrops)
        {
            _mediator = mediator;
            _getDrops = new GetDrops(_mediator);
        }

       

        // LIST
        [HttpGet]
        public async Task<IActionResult> Index(int page = 1, int pageSize = 5)
        {
            var paged = await _mediator.Send(new GetAllMedicosQuery(page, pageSize));

            var vm = new MedicoViewModel
            {
                PageSize = paged.PageSize,
                PageNumber = page,

                TotalCount = paged.TotalItems,
                Medicos = paged.Items
            };           
                        
            return View(vm);
        }
      
        [HttpGet]
        public async Task<IActionResult> goToCreate()
        {            
            var vm = new MedicoViewModel
            {
                Ativo = true,
                Hospitais = await _getDrops.GetHospitaisSelectAsync(),
                Empresas = await _getDrops.GetEmpresas()   

            };

            return View("CreateEditMedico", vm); 
        }

        [HttpGet]
        public async Task<IActionResult> GotoEditClintPage(int id)
        {
            MedicoViewModel paged = await _mediator.Send(new GetByIdMedicosCommand(id));

            paged.Hospitais = await _getDrops.GetHospitaisSelectAsync();
            paged.Empresas = await _getDrops.GetEmpresas();

            var vm = new MedicoViewModel
            {

                Ativo = true,
                Hospitais = await _getDrops.GetHospitaisSelectAsync(),
                Empresas = await _getDrops.GetEmpresas()

            };

            return View("CreateEditMedico", paged);
        }

        [HttpGet]
        public async Task<IEnumerable<MedicoListItemViewModel>> listMedicos(int page =  1, int pageSize = 5)
        {
            var paged =  await _mediator.Send(new GetAllMedicosQuery(page, pageSize));
            return paged.Items;
        }

        // CREATE (POST)
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MedicoViewModel vm, CancellationToken ct)
        {
            if (!ModelState.IsValid)
            {
                vm.Hospitais = await _getDrops.GetHospitaisSelectAsync(vm.IdHospital); 
                return View("CreateEditMedico", vm);
            }

            var command =  CreateMedicoCommand.FromViewModel(vm);
            var id = await _mediator.Send(command, ct);

            // TODO: map + save
            TempData["Success"] = "Médico criado com sucesso.";
           
            return RedirectToAction(nameof(Index));
        }

        // DELETE
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {

            bool sucesso = await _mediator.Send(new DeleteMedicoCommand(id));

            if (sucesso)
                return Ok();

            return BadRequest();

        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromBody] MedicoViewModel vm, CancellationToken ct)
        {
            if (!ModelState.IsValid)
            {
                vm.Hospitais = await _getDrops.GetHospitaisSelectAsync(vm.IdHospital);
                return View("CreateEditMedico", vm);
            }

            var command = CreateMedicoCommand.FromViewModel(vm);
            var id = await _mediator.Send(command, ct);

            // TODO: map + save
            TempData["Success"] = "Médico criado com sucesso.";

            return View("Index", vm);
        }             
    }
}
