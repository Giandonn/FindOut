using System.ComponentModel.DataAnnotations;
using WebApplication2.Model;

namespace WebApplication2.Dto {
	public class CategoriaRequest {
		[MinLength(5)]
		public string Nome { get; set; }

		public Categoria toModel()
			=> new Categoria(Nome);
	}
}
