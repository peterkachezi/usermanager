using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UserManager.BLL.UserModule;
using UserManager.DTO.UserModule;
using UserManager.Models;

namespace UserManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IUserRepository userRepository;

        public HomeController(IUserRepository userRepository,ILogger<HomeController> logger)
        {
            _logger = logger;
            this.userRepository = userRepository;   
           
        }
        public IActionResult Index()
        {
            try
            {
                return View();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

                return View();
            }
        }

        public IActionResult Privacy()
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