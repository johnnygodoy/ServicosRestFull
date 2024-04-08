using System.Data;

namespace ServicosRestFull.Models
{
    public class UsuariosSistema
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public  string  Senha { get; set; }
        public  string Email { get; set; }
        public string Nome { get; set; }

        public ICollection<UsuarioRole> Roles { get; set; } // Adicionando a propriedade Roles
    }
}
