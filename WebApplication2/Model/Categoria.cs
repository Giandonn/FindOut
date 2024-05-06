using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Model {
	public class Categoria {
		public Categoria(string nome) {
			Nome = nome;
		}

		[Key]
		public int Id { get; set; }
		public string Nome { get; set; }
	}
}
