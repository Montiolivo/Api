using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly ILogger<ProdutosController> _logger;

    public ProdutosController(AppDbContext context, ILogger<ProdutosController> logger)
    {
        _context = context;
        _logger = logger;
        if (!_context.Produtos.Any())
        {
            _context.Produtos.AddRange(
                new Produto { Nome = "Produto A", Preco = 10 },
                new Produto { Nome = "Produto B", Preco = 20 }
            );
            _context.SaveChanges();
        }
    }

    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        _logger.LogInformation("Listando produtos...");
        return Ok(_context.Produtos.ToList());
    }


    [HttpPost]
    [Authorize]
    public IActionResult Post([FromBody] Produto produto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _context.Produtos.Add(produto);
        _context.SaveChanges();

        _logger.LogInformation("Produto criado: {Nome}", produto.Nome);

        return CreatedAtAction(nameof(Get), new { id = produto.Id }, produto);
    }
}