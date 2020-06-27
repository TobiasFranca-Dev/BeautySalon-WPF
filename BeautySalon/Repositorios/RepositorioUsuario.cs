using BeautySalon.Models;
using LiteDB;

namespace BeautySalon.Repositorios
{
    public class RepositorioUsuario : BaseRepositorio<Usuario>
    {
        public RepositorioUsuario()
        {
            var result = Login("dev", "1234");

            if (result == null)
            {
                Cadastrar(new Usuario()
                {
                    Ativo = true,
                    Login = "dev",
                    Senha = "1234",
                    Nome = "Developer",
                    Desenvolvedor = true,
                    AcessaClientes = true,
                    CadastraCliente = true,
                    EditaCliente = true,
                    ExcluiCliente = true
                });
            }
        }
        public Usuario Login(string login, string senha)
        {
            using (var db = new LiteDatabase(Shared.DatabaseName))
            {
                var col = db.GetCollection<Usuario>("Usuario");

                return col/*.Include(x => x.PerfilAcessoUsuario)*/
                          .FindOne(x => x.Login.ToLower() == login.ToLower() && x.Senha == senha);
            }
        }

        public bool NomeUsuarioExist(string nomeUsuario)
        {
            using (var db = new LiteDatabase(Shared.DatabaseName))
            {
                var col = db.GetCollection<Usuario>("Usuario");
                return col.Exists(x => x.Login.ToLower() == nomeUsuario.ToLower());
            }
        }

        public override int Cadastrar(Usuario item)
        {
            var id = base.Cadastrar(item);

            if (Shared.UsuarioLogado != null)
            {
                if (Shared.UsuarioLogado.Id == id)
                {
                    Shared.UsuarioLogado = BuscarPorId(id);
                }
            }

            return id;
        }
    }
}
