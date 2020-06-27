using AutoMapper;
using BeautySalon.Models;
using BeautySalon.Repositorios;
using BeautySalon.Services;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BeautySalon.ViewModels
{
    public class ClienteEditeViewModel : BaseViewModel
    {
        #region Atributos        
        private IMapper _mapper;
        private RepositorioCliente _repositorioCliente;
        private string _nome;
        private string _cpf;
        private DateTime _dataNascimento;
        private string _celular;
        private string _telefone;
        private string _email;
        private string _sexo;
        private EnderecoViewModel _endereco;
        #endregion

        #region Commands
        public ICommand SalvarCommand
        {
            get;
        }


        #endregion

        #region Propriedades
        public ObservableCollection<string> ListaUF
        {
            get
            {
                return new ObservableCollection<string>() { "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO" };
            }
        }
        public string Nome
        {
            get { return _nome; }
            set
            {
                SetProperty(ref _nome, value);
                SalvarCommand.CanExecute(null);
            }
        }
        public string Cpf
        {
            get { return _cpf; }
            set { SetProperty(ref _cpf, value); AplicaMAscaraCpf(value); }
        }

        public DateTime DataNascimento
        {
            get { return _dataNascimento; }
            set { SetProperty(ref _dataNascimento, value); }
        }
        public string Celular
        {
            get { return _celular; }
            set { SetProperty(ref _celular, value); }
        }
        public string Telefone
        {
            get { return _telefone; }
            set { SetProperty(ref _telefone, value); }
        }
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }
        public string Sexo
        {
            get { return _sexo; }
            set { SetProperty(ref _sexo, value); }
        }
        public EnderecoViewModel Endereco
        {
            get { return _endereco; }
            set { _endereco = value; }
        }
        public Cliente Cliente { get; set; }
        #endregion


        public ClienteEditeViewModel(int codCliente)
        {
            _repositorioCliente = new RepositorioCliente();
            _mapper = AutoMapperConfig.Mapear();

            SalvarCommand = new Command(SalvarCadastro, CanExecuteSalvarCadastro);

            CarregaDados(codCliente);
        }


        #region Métodos
        private void CarregaDados(int codCliente)
        {
            if (codCliente > 0)
            {
                Cliente = _repositorioCliente.BuscarPorId(codCliente);

                Nome = Cliente.Nome;
                Cpf = Cliente.Cpf;
                DataNascimento = Cliente.DataNascimento;
                Celular = Cliente.Celular;
                Telefone = Cliente.Telefone;
                Email = Cliente.Email;
                Sexo = Cliente.Sexo;
                Endereco = _mapper.Map<EnderecoViewModel>(Cliente.Endereco);
            }
            else
            {
                Endereco = new EnderecoViewModel();
                Cliente = new Cliente();
            }
        }

        private void AplicaMAscaraCpf(string value)
        {
            if (value.Length == )
            {

            }
        }

        private bool CanExecuteSalvarCadastro()
        {
            if (string.IsNullOrWhiteSpace(Nome))
            {
                return false;
            }

            return true;
        }

        private void SalvarCadastro()
        {
            Cliente = _mapper.Map<Cliente>(this);
            Cliente.Usuario = Shared.UsuarioLogado;
        }
        #endregion

    }
}
