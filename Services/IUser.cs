using BlogApi.Models;
using BlogApi.Models.DTO;

namespace BlogApi.Services;

public interface IUser
{
    List<UserDTO> ListUsers();
    User CreateUser(UserCreateDTO user);
    User UpdateUser(User user);
    void DeleteUser(int userId);
}