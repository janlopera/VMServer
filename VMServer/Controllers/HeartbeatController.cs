using Microsoft.AspNetCore.Mvc;
using VMServer.Models;
using VMServer.Services;

namespace VMServer.Controllers;

[ApiController]
[Route("[controller]")]
public class HeartbeatController : ControllerBase
{
    private IDatabaseService _database;

    public HeartbeatController(IDatabaseService _service)
    {
        _database = _service;
    }
    
    [HttpPost]
    public ActionResult Post(ConnectionModel conn)
    {
        _database.HeartBeat(conn);
        return Ok();
    }
}