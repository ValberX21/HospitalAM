using HospitalAM.Application.Commands;
using HospitalAM.Application.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAM.Presentation.Controllers
{
    public class LoginController : Controller
    {
        private readonly IMediator _mediator;
        public LoginController(IMediator mediator) => _mediator = mediator;

        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
                return View("Index", login);

            LoginResult lg = await _mediator.Send(new LoginCommand(login.Email, login.Password, login.RememberMe));
           
            ViewBag.Message = lg.TipoUsuario;

            if (lg.Success)
                 return View("~/Views/Home/Index.cshtml");

            return View("~/Views/Login/Index.cshtml");
        }
    }
}
