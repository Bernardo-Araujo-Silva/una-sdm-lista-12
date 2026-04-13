using Microsoft.AspNetCore.Mvc;
using NikeStoreApi.Data;
using NikeStoreApi.Models;

namespace NikeStoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidosController : ControllerBase
{
    private readonly AppDbContext _context;

    public PedidosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult CriarPedido(Pedido pedido)
    {
        var produto = _context.Produtos.Find(pedido.ProdutoId);

        if (produto == null)
            return NotFound("Produto não encontrado.");

        // 1. Validar estoque
        if (produto.QuantidadeEstoque < pedido.QuantidadeItens)
            return Conflict("Estoque insuficiente para este modelo.");

        // 2. Baixa de estoque
        produto.QuantidadeEstoque -= pedido.QuantidadeItens;

        pedido.DataPedido = DateTime.Now;

        _context.Pedidos.Add(pedido);
        _context.SaveChanges();

        // 3. Log
        if (produto.Nome.Contains("Air Jordan"))
        {
            Console.WriteLine("Alerta de Hype: Um Air Jordan acaba de ser vendido!");
        }

        return Ok(pedido);
    }

    [HttpGet]
    public IActionResult ListarDetalhado()
    {
        var resultado = _context.Pedidos.Select(p => new
        {
            p.Id,
            Produto = _context.Produtos.FirstOrDefault(x => x.Id == p.ProdutoId).Nome,
            Cliente = _context.Clientes.FirstOrDefault(x => x.Id == p.ClienteId).NomeCompleto,
            p.QuantidadeItens,
            p.DataPedido
        });

        return Ok(resultado);
    }
}