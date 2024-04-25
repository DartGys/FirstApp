using Microsoft.AspNetCore.Mvc;
using TaskBoard.BLL.Interfaces.Services;

namespace TaskBoard.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PriorityController : ControllerBase
{
    private readonly IPriorityService _priorityService;

    public PriorityController(IPriorityService priorityService)
    {
        _priorityService = priorityService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var models = await _priorityService.GetAsync();

        return Ok(models);
    }
}