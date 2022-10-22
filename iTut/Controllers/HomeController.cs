using iTut.Constants;
using iTut.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace iTut.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if(User.Identity.IsAuthenticated)
            {
                if (User.IsInRole(RoleConstants.Parent))
                {
                    return RedirectToAction("Index", "Parent");
                }
                else if (User.IsInRole(RoleConstants.Educator))
                {
                    return RedirectToAction("Index", "Educator");
                }
                else if (User.IsInRole(RoleConstants.Student))
                {
                    return RedirectToAction("Index", "Student");
                }
                else if (User.IsInRole(RoleConstants.SubjectCoordinator))
                {
                    return RedirectToAction("Index", "Coordinator");
                }
                else
                {
                    return RedirectToAction("Index", "HOD");
                }
            }
            return View();
        }
        
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Disclaimer()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
