using System.ComponentModel.DataAnnotations;
using WebApplication2.Models; 

namespace WebApplication2.Dto
{
    public class UsuarioDto
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public Usuario ToModel()
        {
            return new Usuario
            {
                Nome = this.Nome,
                Email = this.Email,
                Senha = this.Senha
            };
        }
    }
}
