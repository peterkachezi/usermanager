using UserManager.DTO.UserModule;

namespace UserManager.BLL.UserModule
{
    public interface IUserRepository
    {
        Task<Response> UserLogin(UserDTO userDTO);
    }
}