using Microsoft.AspNetCore.Mvc;
using VMServer.Models;
using VMServer.Services;

namespace VMServer.Controllers;

[ApiController]
[Route("[controller]")]

public class ShutdownController : ControllerBase
{
    private IDatabaseService _database;

    public ShutdownController(IDatabaseService _service)
    {
        _database = _service;
    }

    [HttpPost]
    public ActionResult Post(ConnectionModel conn)
    {
        _database.Shutdown(conn);
        return Ok();
    }
}