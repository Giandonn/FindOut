using WebApplication2.Model;

namespace WebApplication2.Dto {
	public class ProdutoResponse {
		public ProdutoResponse(Produto produto) {
			Nome = produto.Nome;
			Categoria = produto.Categoria;
		}

		public string Nome { get; }
		public Categoria Categoria { get; }
	}
}
