namespace SiteVinho.ViewModels
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Nome { get; set; }
        public ICollection<UsuarioRole> Usuarios { get; set; }
    }
}
