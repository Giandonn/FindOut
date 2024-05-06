using System.ComponentModel.DataAnnotations;
using WebApplication2.Model;

namespace WebApplication2.Dto {
	public class ProdutoRequest {

		[MinLength(5)]
		public string Nome { get; set; }
		[Required]
		public int CategoriaId { get; set; }

		public Produto ToModel()
			=> new Produto(Nome, CategoriaId);

	}
}
