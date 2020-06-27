using BeautySalon.Models;
using BeautySalon.Repositorios;
using BeautySalon.Views;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace BeautySalon.ViewModels
{
    public class ClienteListViewModel : BaseViewModel
    {
        #region Atributos
        private RepositorioCliente repositorio;
        private ObservableCollection<Cliente> _lista;
        private Cliente _clienteSelecionado;
        private ICommand _novoClienteCommand;
        private ICommand _editaClienteCommand;
        private ICommand _excluirClienteCommand;
        #endregion

        #region Commands
        public ICommand NovoClienteCommand
        {
            get { return _novoClienteCommand ?? (_novoClienteCommand = new Command(() => CadastraNovoCliente(), CanExecuteCadastraNovoCliente)); }
        }

        public ICommand EditaClienteCommand
        {
            get { return _editaClienteCommand ?? (_editaClienteCommand = new Command(() => EditaCliente(), CanExecuteEditaCliente)); }
        }

        public ICommand ExcluirClienteCommand
        {
            get { return _excluirClienteCommand ?? (_excluirClienteCommand = new Command(() => ExcluiCliente(), CanExecuteExcluiCliente)); }
        }

        #endregion

        #region Propriedades
        public ObservableCollection<Cliente> Lista
        {
            get { return _lista; }
            set { SetProperty(ref _lista, value); }
        }
        public Cliente ClienteSelecionado
        {
            get { return _clienteSelecionado; }
            set { SetProperty(ref _clienteSelecionado, value); }
        }
        #endregion

        public ClienteListViewModel()
        {
            repositorio = new RepositorioCliente();
            CarregarDados();
        }

        #region Metodos

        private void CarregarDados()
        {
            Lista = new ObservableCollection<Cliente>()
            {
                new Cliente(){Id = 1, Nome = "Cliente 1", Celular = "(27)99772-2661", DataCadastro = DateTime.Now}
            };
        }

        private bool CanExecuteCadastraNovoCliente()
        {
            return Shared.UsuarioLogado.CadastraCliente;
        }

        private void CadastraNovoCliente()
        {
            var frm = new ClienteEditeView(0);
            frm.ShowDialog();
        }

        private bool CanExecuteEditaCliente()
        {
            return Shared.UsuarioLogado.EditaCliente;
        }

        private void EditaCliente()
        {
            if (ClienteSelecionado == null)
            {
                MessageBox.Show("Selecione um cliente na lista!", "Atenção", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            var frm = new ClienteEditeView(ClienteSelecionado.Id);
            frm.ShowDialog();
            CarregarDados();

        }

        private bool CanExecuteExcluiCliente()
        {
            return Shared.UsuarioLogado.ExcluiCliente;
        }

        private void ExcluiCliente()
        {
            if (ClienteSelecionado == null)
            {
                MessageBox.Show("Selecione um cliente na lista!", "Atenção", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (MessageBox.Show("Deseja realmente excluir este cadastro?", "Atenção", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
                return;
            }

            if (ValidaClienteExclusao() == false)
            {
                MessageBox.Show("Não é possível excluir o cliente selecionado pois ele possui regitros vinculados a ele.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            repositorio.Excluir(ClienteSelecionado);
            MessageBox.Show("Cliente excluido com sucesso!", "Aviso", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        private bool ValidaClienteExclusao()
        {
            return true;
        }
        #endregion
    }
}
