using Kanban.Application.Quadros;
using KanBan.Domain.Models;
using KanBan.Domain.Models.Requests;
using KanBan.Domain.Models.Response.Quadro;
using Microsoft.AspNetCore.Mvc;

namespace KanbanApi.Quadros;

[Route("[controller]")]
[ApiController]
public class QuadroController(IQuadroService _quadroService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(AddQuadroResponse), StatusCodes.Status201Created)]
    public IActionResult AddQuadro(AddQuadroRequest request)
    {
        var result = _quadroService.AddQuadro(request);
        return Ok(result);
    }

    [HttpGet]
    public IActionResult GetQadros()
    {
        return Ok("Teste de get");
    }
}