using BlogApi.Models;
using BlogApi.Models.DTO;

namespace BlogApi.Services;

public interface IUser
{
    List<UserDTO> ListUsers();
    UserDTO FindUser(int id);
    User CreateUser(UserCreateDTO user);
    User UpdateUser(UserDTO user);
    void DeleteUser(int userId);
}