using FirstApi.Models.DTOs;
using FirstApi.Models;
using FirstAPI.Models;
using FirstAPI.Models.DTOs;

namespace FirstApi.Interfaces
{
    public interface IUserService
    {
        public UserDTO Login(UserDTO userDTO);
        public UserDTO Register(UserDTO userDTO);
    }
}
