using DatabaseR;
using Microsoft.AspNetCore.Mvc;
using Users.Models;
using Users.Services;

namespace Users.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(CardsApi context, IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet]
    public IActionResult GetUser(string email)
    {
        try
        {
            User user = _userService.GetUser(email);
            return Ok(user);
        }
        catch (System.Exception e)
        {
            return BadRequest("Error GetUser : " + e);
            throw;
        }
    }
    [HttpPost]
    public IActionResult PostUser(User user)
    {
        try
        {
            User newUser = _userService.PostUser(user);

            return Ok(newUser);
        }
        catch (System.Exception e)
        {
            return BadRequest("Error PostUser : " + e);
            throw;
        }
    }

    [HttpPut]
    public IActionResult PutUser(User user)
    {
        try
        {
            User newUser = _userService.UpdateUser(user);

            return Ok(newUser);
        }
        catch (System.Exception e)
        {
            return BadRequest("Error PutUser : " + e);
            throw;
        }
    }
    [HttpDelete]
    public IActionResult DeleteUser(string email)
    {
        try
        {
            User deletedUser = _userService.DeleteUser(email);

            return Ok(deletedUser);
        }
        catch (System.Exception e)
        {
            return BadRequest("Error DeleteUser : " + e);
            throw;
        }
    }
}

