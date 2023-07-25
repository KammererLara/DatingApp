using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController] //
[Route("api/[controller]")] // gibt Route an, worauf dieser Controller hören soll ...hier: /api/users
public class UsersController : ControllerBase
{
    //dependency Injection:
    private readonly DataContext _context;
    
    // Konstruktor für DI nötig
    public UsersController(DataContext context)
    {
        _context = context;
    }
    
    // // synchron
    // // Endpoint
    // [HttpGet] // --> GET /api/users
    // // ActionResult ermöglicht mir auch einen Response mit notFound,
    // // wenn ich nur IEnumerable returne kann ich nur die Liste zurückgeben
    // public ActionResult<IEnumerable<AppUser>> GetUsers()
    // {
    //     var users = _context.Users.ToList(); //fragt schon meine User aus der Users Tabelle der DB ab???
    //     return users;
    // }

    // [HttpGet("{id}")]
    // public ActionResult<AppUser> GetUser(int id)
    // {
    //     return _context.Users.Find(id);
    // }
    
    // asynchron
    // Endpoint
    [HttpGet] // --> GET /api/users
    // ActionResult ermöglicht mir auch einen Response mit notFound,
    // wenn ich nur IEnumerable returne kann ich nur die Liste zurückgeben
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await _context.Users.ToListAsync(); //fragt schon meine User aus der Users Tabelle der DB ab???
        return users;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        return await _context.Users.FindAsync(id);
    }
}