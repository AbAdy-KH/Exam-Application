using ExamApp.Mvc.Contracts;
using ExamApp.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExamApp.Mvc.Controllers
{
    public class UserController : Controller
    {
        private readonly IAuthService _authService;

        public UserController(IAuthService authService)
        {
            _authService = authService;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(AuthunticationVM obj)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var isAuthenticated = await _authService.Authunticate(obj);
                    if (isAuthenticated)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("", "Invalid data");
                return View(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Register(RegisterVM obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isRegistered = await _authService.Register(obj);
                    if (isRegistered)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("", "Invalid data");
                return View(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Logout(RegisterVM obj)
        {
            await _authService.Logout();

            return RedirectToAction("Index", "Home");
        }
    }
}
