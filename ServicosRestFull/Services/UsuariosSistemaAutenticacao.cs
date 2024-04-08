using ServicosRestFull.Models;

namespace ServicosRestFull.Services
{
    public class UsuariosSistemaAutenticacao
    {
        private readonly IServiceProvider _serviceProvider;

        public UsuariosSistemaAutenticacao(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public bool Login(string login, string senha)
        {
            // Resolva o contexto do banco de dados dinamicamente
            using var scope = _serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<MeuBanco>();

            // Faça a lógica de autenticação com o contexto do banco de dados
            var usuario = dbContext.UsuarioSistema.FirstOrDefault(s => s.Login == login && s.Senha == senha);
            return usuario != null;
        }
    }
}
