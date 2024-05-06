using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Dto;
using WebApplication2.Model;

namespace WebApplication2.Controllers {
	[Route("/api/v1.0/produto")]
	[ApiController]
	public class ProdutoController : ControllerBase {
		private readonly DataContext _context;

		public ProdutoController(DataContext context) {
			_context = context;
		}

		[HttpPost]
		public ActionResult<ProdutoRequest> Post([FromBody] ProdutoRequest produtoRequest) {
			var categoriaENulo = _context.Categorias.FirstOrDefault(op => op.Id == produtoRequest.CategoriaId) == null;

			if (categoriaENulo)
				ModelState.AddModelError("CategoriaId", "Id de categoria nao encontrado!");

			if (ModelState.IsValid) {
				_context.Produtos.Add(produtoRequest.ToModel());
				_context.SaveChanges();
				return produtoRequest;
			}
			return BadRequest(ModelState);
		}

		[HttpGet("id:int")]
		public ActionResult<ProdutoResponse> GetById(int id) {
			var produto = _context.Produtos
				.Include(op => op.Categoria)
				.FirstOrDefault(op => op.Id == id);

			return new ProdutoResponse(produto);
		}
	}
}
