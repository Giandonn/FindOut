using Microsoft.AspNetCore.Mvc;
using WebApplication2.Dto;
using WebApplication2.Model;

namespace WebApplication2.Controllers {
	[ApiController]
	[Route("/api/v1.0/categoria")]
	public class CategoriaController : ControllerBase {
		[HttpPost]
		public ActionResult<Categoria> Post([FromServices] DataContext dataContext, [FromBody] CategoriaRequest categoriaRequest) {
			if (ModelState.IsValid) {
				var categoria = categoriaRequest.toModel();
				dataContext.Categorias.Add(categoria);
				dataContext.SaveChanges();
				return categoria;
			}
			return BadRequest(ModelState);
		}

		[HttpGet]
		public ActionResult<List<Categoria>> Get([FromServices] DataContext dataContext)
			=> dataContext.Categorias.ToList();

		[HttpPut]
		public ActionResult<Categoria> Put([FromServices] DataContext dataContext, [FromBody] Categoria categoria) {
			var categoriaENulo = dataContext.Categorias.FirstOrDefault(categoria) == null;
			if (categoriaENulo)
				ModelState.AddModelError("CategoriaId", "Id da categoria não encontrado!");

			if (ModelState.IsValid) {
				dataContext.Categorias.Update(categoria);
				dataContext.SaveChanges();
				return categoria;
			}
			return BadRequest(ModelState);
		}

		[HttpDelete("id:int")]
		public ActionResult Delete([FromServices] DataContext dataContext, int id) {
			var categoria = dataContext.Categorias.Find(id);
			if (categoria == null)
				ModelState.AddModelError("CategoriaId", "Id da categoria não encontrado!");

			if (ModelState.IsValid) {
				dataContext.Categorias.Remove(categoria);
				dataContext.SaveChanges();
				return Ok();
			}
			return BadRequest(ModelState);

		}

	}
}
