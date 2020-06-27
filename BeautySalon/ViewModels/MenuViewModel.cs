using BeautySalon.Views;
using System.Windows.Input;

namespace BeautySalon.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        public MenuViewModel()
        {
            NomeUsuario = Shared.UsuarioLogado.Nome;
        }

        private string _nomeUsuario;
        private ICommand _clientesCommand;


        public string NomeUsuario
        {
            get { return _nomeUsuario; }
            set { SetProperty(ref _nomeUsuario, value); }
        }


        public ICommand ClientesCommand
        {
            get { return _clientesCommand ?? (_clientesCommand = new Command(() => OpenClientes(), CanExecuteClientes)); }
        }

        public bool CanExecuteClientes()
        {
            return Shared.UsuarioLogado.AcessaClientes;
        }

        public void OpenClientes()
        {
            var frm = new ClienteListView();
            frm.ShowDialog();
        }

    }
}
