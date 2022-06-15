using Microsoft.AspNetCore.Mvc;
using VMServer.Models;
using VMServer.Services;

namespace VMServer.Controllers;

[ApiController]
[Route("[controller]")]

public class ReleaseController : ControllerBase
{
    private IDatabaseService _database;

    public ReleaseController(IDatabaseService _service)
    {
        _database = _service;
    }
    
    [HttpPost]
    public ActionResult Post(ConnectionModel conn)
    {
        _database.ReleaseVM(conn);
        return Ok();
    }
}