﻿using AutoMapper;
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

    public UserDTO FindUser(int id)
    {
        var existingUser = _dbContext.Users.FirstOrDefault((u => u.Id.Equals(id)));
        if (existingUser == null)
        {
            _logger.LogError("User to find does not exist {id}", id);
            throw new RecordNotFoundException($"User does not exist {id}");
        }

        var mappedUser = _mapper.Map<UserDTO>(existingUser);
        return mappedUser;
    }

    public User CreateUser(UserCreateDto user)
    {
        var userToSave = _mapper.Map<User>(user);
        userToSave.CreatedAt = DateTime.UtcNow;
        _dbContext.Users.Add(userToSave);
        _dbContext.SaveChanges();
        return userToSave;
    }

    public User UpdateUser(UserDTO user)
    {
        var existingUser = _dbContext.Users.FirstOrDefault(u => u.Id.Equals(user.Id));
        if (existingUser == null)
        {
            _logger.LogError("User does not exist {userId}", user.Id);
            throw new RecordNotFoundException("User does not exist");
        }

        _mapper.Map(user, existingUser);
        existingUser.UpdatedAt = DateTime.UtcNow;
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
            throw new RecordNotFoundException("User does not exist ");
        }

        _dbContext.Users.Remove(existingUser);
        _dbContext.SaveChanges();
    }
}