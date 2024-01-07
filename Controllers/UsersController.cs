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

    [HttpPost]
    public IActionResult Create([FromBody] UserCreateDTO user)
    {
        return Created("", _userService.CreateUser(user));
    }

    [HttpPut]
    public IActionResult Update([FromBody] User user)
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