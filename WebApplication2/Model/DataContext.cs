using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Model {
	public class DataContext : DbContext {

		public DataContext() : base() { }

		public DataContext(DbContextOptions options) : base(options) { }



		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			optionsBuilder.UseSqlServer
				("Password=root;Persist Security Info=True;User ID=root;Initial Catalog=prodCat;Data Source=server");
		}

		public DbSet<Produto> Produtos { get; set; }
		public DbSet<Categoria> Categorias { get; set; }
	}
}
