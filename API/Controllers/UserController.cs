using DatabaseR;
using Microsoft.AspNetCore.Mvc;

namespace Users.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly CardsApi _context;

    public UserController(CardsApi context)
    {
        _context = context;
    }
}

