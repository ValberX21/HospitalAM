using HospitalAM.Presentation.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospitalAM.Presentation.Controllers
{
    public class MedicoController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var vm = new MedicoViewModel
            {
                Hospitais = await GetHospitaisSelectAsync(),
                Medicos = Enumerable.Empty<MedicoListItemViewModel>()
            };
            return View(vm);
        }

        private async Task<IEnumerable<SelectListItem>> GetHospitaisSelectAsync(int? selectedId = null)
        {
            var items = new List<SelectListItem>
    {
                new() { Value = "1", Text = "Hospital São Lucas" },
                new() { Value = "2", Text = "Hospital Vida Nova" },
                new() { Value = "3", Text = "Clínica Central" },
                new() { Value = "4", Text = "Hospital Santa Clara" },
                new() { Value = "5", Text = "Hospital Universitário" },
            };

                    if (selectedId.HasValue)
                        items.ForEach(i => i.Selected = (i.Value == selectedId.Value.ToString()));

            return items;
        }
    }
}
