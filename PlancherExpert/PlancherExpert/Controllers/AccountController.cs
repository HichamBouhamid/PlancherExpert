using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PlancherExpert.Data;
using PlancherExpert.Models;

namespace PlancherExpert.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Utilisateur user)
        {
            var userInDb = _context.Utilisateur.SingleOrDefault(u => u.Email == user.Email && u.Password == user.Password);

            var CommandesCount = _context.Commande.Count();
            var CouvrePlancherCount = _context.CouvrePlancher.Count();
            var UtilisateurCount = _context.Utilisateur.Where(u => u.UserType != "Admin").Count();

            if (userInDb == null)
            {
                ModelState.AddModelError("Email", "Invalid Email");
                ModelState.AddModelError("Password", "Invalid Password");
                return View();
            }

            HttpContext.Session.SetString("UserId", userInDb.Id.ToString());
            HttpContext.Session.SetString("UserName", userInDb.Name);
            HttpContext.Session.SetString("UserEmail", userInDb.Email);
            HttpContext.Session.SetString("UserType", userInDb.UserType);

            if (userInDb.UserType == "Admin")
            {
                return RedirectToAction("Index", "Admin", new { CommandesCount = CommandesCount, CouvrePlancherCount = CouvrePlancherCount, UtilisateurCount = UtilisateurCount });
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
    public class AdminOnlyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = filterContext.HttpContext.Session;
            if (session.GetString("UserEmail") == null ||
                session.GetString("UserType") != "Admin")
            {
                filterContext.Result = new RedirectResult("/Home/Index");
            }
        }
    }

    public class FreelancerOnlyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = filterContext.HttpContext.Session;
            if (session.GetString("UserEmail") == null ||
                session.GetString("UserType") != "Supervisor")
            {
                filterContext.Result = new RedirectResult("/Home/Index");
            }
        }
    }
}
