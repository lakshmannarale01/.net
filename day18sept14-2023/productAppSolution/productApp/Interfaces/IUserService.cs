using productApp.Models.DTOs;
using productApp.Models;

namespace productApp.Interfaces
{
    public interface IUserService
    {
        public UserDTO Login(UserDTO userDTO);
        public UserDTO Register(UserDTO userDTO);
    }
}
