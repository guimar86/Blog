using BlogApi.Models;
using BlogApi.Models.DTO;
using BlogApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUser _userService;

    public UsersController(IUser userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult List()
    {
        return Ok(_userService.ListUsers());
    }

    [HttpGet]
    [Route("{id:int}", Name = "UserById")]
    public IActionResult FindById([FromRoute] int id)
    {
        var existingUser = _userService.FindUser(id);
        return Ok(existingUser);
    }

    [HttpPost]
    public IActionResult Create([FromBody] UserCreateDto user)
    {
        var createdUser = _userService.CreateUser(user);
        return CreatedAtRoute("UserById", new { id = createdUser.Id }, createdUser);
    }

    [HttpPut]
    public IActionResult Update([FromBody] UserDTO user)
    {
        return Ok(_userService.UpdateUser(user));
    }

    [HttpDelete]
    [Route("{userId:int}")]
    public IActionResult Delete(int userId)
    {
        _userService.DeleteUser(userId);
        return Ok();
    }
}