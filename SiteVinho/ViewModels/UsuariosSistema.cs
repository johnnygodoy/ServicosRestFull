namespace SiteVinho.ViewModels
{
    public class UsuariosSistema
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }

        public ICollection<UsuarioRole> Roles { get; set; }
    }
}
