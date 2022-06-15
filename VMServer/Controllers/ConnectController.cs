using Microsoft.AspNetCore.Mvc;
using VMServer.Models;
using VMServer.Services;

namespace VMServer.Controllers;

[ApiController]
[Route("[controller]")]
public class ConnectController : ControllerBase
{
    private IDatabaseService _database;

    public ConnectController(IDatabaseService _service)
    {
        _database = _service;
    }
    
    [HttpGet]
    public ActionResult<ConnectionModel> Get()
    {
        var conn = _database.GetAvailableVM();
        if (conn == null) return StatusCode(500);
        return Ok(conn);
    }
}