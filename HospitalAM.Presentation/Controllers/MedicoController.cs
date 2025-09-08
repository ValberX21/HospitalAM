using HospitalAM.Application.Queries;
using HospitalAM.Core.Entities;
using HospitalAM.Presentation.ViewModel;
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
        public async Task<IActionResult> Index()
        {
            var vm = new MedicoViewModel
            {
                //Hospitais = await GetHospitaisSelectAsync(),
                //Medicos = Enumerable.Empty<MedicoListItemViewModel>(),
                PageSize = 10,
                PageNumber = 1
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
                Hospitais = await GetHospitaisSelectAsync()    ,
                Empresas = await GetEmpresasSelectAsync()   

            };

            return View("CreateEditMedico", vm); 
        }

        // CREATE (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MedicoViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Hospitais = await GetHospitaisSelectAsync(vm.IdHospital); // repopulate on error
                return View("CreateEditMedico", vm);
            }

            // TODO: map + save
            TempData["Success"] = "Médico criado com sucesso.";
            return RedirectToAction(nameof(Index));
        }





















        // EDIT (GET)
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            // TODO: get from DB
            // if (medico == null) return NotFound();

            var vm = new MedicoViewModel
            {
                IdMedico = id,
                IdEmpresa = 1,
                IdHospital = 2,
                Nome = "Dr. Exemplo",
                CPF = "12345678901",
                DataNascimento = new DateTime(1985, 5, 23),
                Genero = "M",
                Email = "exemplo@hospital.com",
                Telefone = "11999999999",
                Endereco = "Rua X, 123",
                CRM = "12345-SP",
                Especialidade = "Clínico Geral",
                Ativo = true,
                Hospitais = await GetHospitaisSelectAsync(2)
            };

            return View("CreateEditMedico", vm);
        }

        // EDIT (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MedicoViewModel vm)
        {
            if (id != vm.IdMedico) return BadRequest();

            if (!ModelState.IsValid)
            {
                vm.Hospitais = await GetHospitaisSelectAsync(vm.IdHospital);
                return View("CreateEditMedico", vm);
            }

            // TODO: map + update
            TempData["Success"] = "Médico atualizado com sucesso.";
            return RedirectToAction(nameof(Index));
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
