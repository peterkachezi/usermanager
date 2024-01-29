using Newtonsoft.Json;
using System.Text;
using UserManager.BLL.Util;
using UserManager.DTO.UserModule;
namespace UserManager.BLL.UserModule
{
    public class UserRepository : IUserRepository
    {
        public async Task<Response> UserLogin(UserDTO userDTO)
        {
            try
            {
                var client = new HttpClient();

                var json = JsonConvert.SerializeObject(userDTO);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(API.ApiUrl + "auth/login", content);

                if (response.IsSuccessStatusCode)
                {
                    var JsonResult = await response.Content.ReadAsStringAsync(); 

                    var result = JsonConvert.DeserializeObject<Response>(JsonResult);             

                    return result;
                }               

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }
    }
}
