using System.Data;

namespace SiteVinho.ViewModels
{
    public class UsuarioRole
    {
        public int UsuarioId { get; set; }
        public UsuariosSistema Usuario { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
