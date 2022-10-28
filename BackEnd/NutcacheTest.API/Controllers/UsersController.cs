using Microsoft.AspNetCore.Mvc;
using NutcacheTest.Entities.Entity;
using NutcacheTest.Services;

namespace NutcacheTest.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;

    public UsersController(IUsersService usersService) { 
        _usersService = usersService;
    }

    [HttpGet(Name = "Users")]
    public ActionResult<dynamic> Get()
    {
        var users = _usersService.GetAllUsers();
        return users.Any() ? Ok(users) : NotFound();
    }

    [HttpPost(Name = "Users")]
    public async Task<IActionResult> Post(User user)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        var _user = await _usersService.AddUser(user);
        return _user != null ? Ok(_user) : BadRequest("Unable to create user");
    }

    [HttpDelete(Name = "Users")]
    public async Task<IActionResult> Delete(int userId)
    {
        var users = await _usersService.DeleteUser(userId);
        return users ? Ok("deleted") : NotFound("User not found");
    }

    [HttpPatch(Name = "Users")]
    public async Task<IActionResult> Patch(User user)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        var _user = await _usersService.EditUser(user);
        return _user != null ? Ok(_user) : NotFound("User not found");
    }
}
