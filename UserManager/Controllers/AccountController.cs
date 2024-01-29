using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserManager.BLL.UserModule;
using UserManager.DTO.UserModule;

namespace UserManager.Controllers
{
    public class AccountController : Controller
    {

        private readonly IUserRepository userRepository;
        public AccountController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Login(UserDTO userDTO)
        {
            try
            {
                var results = await userRepository.UserLogin(userDTO);

                if (results != null)
                {
                    return RedirectToAction("Index", "Home", new { area = "" });
                }
                else
                {
                    TempData["Error"] = "Invalid user account / Account does not exist";

                    return RedirectToAction("Index", "Account");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return Json(new { success = false, responseText = "" + "Your session has expired, you need to login again!" + "" });
            }
        }
    }
}
