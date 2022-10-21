using iTut.Constants;
using iTut.Data;
using iTut.Models.Users;
using iTut.Models.ViewModels.HOD;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace iTut.Controllers
{
    [Authorize(Roles = RoleConstants.HOD)]
    public class HODController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<HODController> _logger;

        public HODController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, ILogger<HODController> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var hod = _context.HOD.Where(h => h.UserId == _userManager.GetUserId(User)).FirstOrDefault();

            var model = new HODIndexViewModel
            {
                HodUser = hod
            };

            return View(model);
        }
    }
}
