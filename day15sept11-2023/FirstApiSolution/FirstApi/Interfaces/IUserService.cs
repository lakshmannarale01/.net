using FirstApi.Models.DTOs;
using FirstApi.Models;

namespace FirstApi.Interfaces
{
    public interface IUserService
    {
        public User Login(UserDTO userDTO);
        public User Register(UserDTO userDTO);
    }
}
