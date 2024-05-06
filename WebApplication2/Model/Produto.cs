using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Model {
	public class Produto {
		public Produto(string nome, int categoriaId) {
			Nome = nome;
			CategoriaId = categoriaId;
		}

		[Key]
		public int Id { get; set; }
		public string Nome { get; set; }
		public int CategoriaId { get; set; }
		public Categoria Categoria { get; set; }
	}
}
