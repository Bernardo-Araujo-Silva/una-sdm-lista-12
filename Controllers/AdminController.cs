using Microsoft.AspNetCore.Mvc;
using NikeStoreApi.Data;

namespace NikeStoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    private readonly AppDbContext _context;

    public AdminController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("balanco")]
    public IActionResult Balanco()
    {
        var faturamento = _context.Pedidos.Sum(p =>
            p.QuantidadeItens *
            _context.Produtos.First(prod => prod.Id == p.ProdutoId).Preco
        );

        var estoqueZero = _context.Produtos.Count(p => p.QuantidadeEstoque == 0);

        return Ok(new
        {
            FaturamentoTotal = faturamento,
            ProdutosSemEstoque = estoqueZero
        });
    }
}