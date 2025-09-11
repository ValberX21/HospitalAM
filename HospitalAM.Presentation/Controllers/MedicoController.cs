using HospitalAM.Application.Commands;
using HospitalAM.Application.DTOs;
using HospitalAM.Application.Handlers;
using HospitalAM.Application.Queries;
using HospitalAM.Application.ViewModel;
using HospitalAM.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospitalAM.Presentation.Controllers
{
    public class MedicoController : Controller
    {
        private readonly IMediator _mediator;
        public MedicoController(IMediator mediator)
        {
            _mediator = mediator;
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

        // CREATE (GET)
        [HttpGet]
        public async Task<IActionResult> goToCreate()
        {            
            var vm = new MedicoViewModel
            {
                Ativo = true,
                Hospitais = await GetHospitaisSelectAsync(),
                Empresas = await GetEmpresasSelectAsync()   

            };

            return View("CreateEditMedico", vm); 
        }

        [HttpGet]
        public async Task<IActionResult> GotoEditClintPage(int id)
        {
            MedicoViewModel paged = await _mediator.Send(new GetByIdMedicosCommand(id));

            paged.Hospitais = await GetHospitaisSelectAsync();
            paged.Empresas = await GetEmpresasSelectAsync();

            var vm = new MedicoViewModel
            {

                Ativo = true,
                Hospitais = await GetHospitaisSelectAsync(),
                Empresas = await GetEmpresasSelectAsync()

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
                vm.Hospitais = await GetHospitaisSelectAsync(vm.IdHospital); 
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
                vm.Hospitais = await GetHospitaisSelectAsync(vm.IdHospital);
                return View("CreateEditMedico", vm);
            }

            var command = CreateMedicoCommand.FromViewModel(vm);
            var id = await _mediator.Send(command, ct);

            // TODO: map + save
            TempData["Success"] = "Médico criado com sucesso.";

            return View("Index", vm);
        }

        


        // Helper to populate dropdown
        private async Task<IEnumerable<SelectListItem>> GetHospitaisSelectAsync(int? hospitalId = null)
        {
            List<Hospital> hospitais = await _mediator.Send(new GetAllHospitaisQuery(hospitalId));

            if (hospitais == null || hospitais.Count == 0)
                return Enumerable.Empty<SelectListItem>();

            return hospitais.Select(h => new SelectListItem
            {
                Value = h.IdHospital.ToString(),
                Text = h.Nome,
                Selected = (hospitalId.HasValue && h.IdHospital == hospitalId.Value)
            });
        }

        private async Task<IEnumerable<SelectListItem>> GetEmpresasSelectAsync(int? empresaId = null)
        {
            List<Empresa> empresas = await _mediator.Send(new GetAllEmpresasQuery(empresaId));

            if (empresas == null || empresas.Count == 0)
                return Enumerable.Empty<SelectListItem>();

            return empresas.Select(h => new SelectListItem
            {
                Value = h.IdEmpresa.ToString(),
                Text = h.Nome,
                Selected = (empresaId.HasValue && h.IdEmpresa == empresaId.Value)
            });
        }
    }
}
