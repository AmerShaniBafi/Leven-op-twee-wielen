using Microsoft.AspNetCore.Mvc;
using O2W.DTOs;
using O2W.Services;

namespace O2W.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MotorRoutesController : ControllerBase
{
    private readonly MotorRouteService _service;

    public MotorRoutesController(MotorRouteService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var routes = await _service.GetAllAsync();
        return Ok(routes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int id)
    {
        var route = await _service.GetByIdAsync(id);

        if (route == null)
            return NotFound();

        return Ok(route);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] MotorRouteDto dto)
    {
        var created = await _service.CreateAsync(dto);

        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }
}