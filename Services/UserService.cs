using AutoMapper;
using BlogApi.Data;
using BlogApi.Models;
using BlogApi.Models.DTO;

namespace BlogApi.Services;

public class UserService : IUser
{
    private readonly BlogDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<UserService> _logger;

    public UserService(BlogDbContext dbContext, IMapper mapper, ILogger<UserService> logger)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _logger = logger;
    }

    public List<UserDTO> ListUsers()
    {
        var users = _mapper.Map<List<UserDTO>>(_dbContext.Users.ToList());
        return users;
    }

    public User CreateUser(UserCreateDTO user)
    {
        var userToSave = _mapper.Map<User>(user);
        _dbContext.Users.Add(userToSave);
        _dbContext.SaveChanges();
        return userToSave;
    }

    public User UpdateUser(User user)
    {
        var existingUser = _dbContext.Users.FirstOrDefault(u => u.Id.Equals(user.Id));

        if (existingUser == null)
        {
            _logger.LogError("User does not exist {userId}", user.Id);
            throw new Exception("User does not exist");
        }

        _logger.LogInformation("Before mapping {user}",existingUser);
        _mapper.Map(user, existingUser);
        _logger.LogInformation("After mapping {user}",existingUser);
        
        _dbContext.Users.Update(existingUser);
        _dbContext.SaveChanges();

        return existingUser;
    }

    public void DeleteUser(int userId)
    {
        var existingUser = _dbContext.Users.FirstOrDefault(u => u.Id.Equals(userId));
        if (existingUser == null)
        {
            _logger.LogError("User does not exist {userId}", userId);
            throw new Exception("User does not exist ");
        }

        _dbContext.Users.Remove(existingUser);
        _dbContext.SaveChanges();
    }
}