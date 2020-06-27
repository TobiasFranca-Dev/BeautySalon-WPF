namespace BeautySalon.ViewModels
{
    public class EnderecoViewModel : BaseViewModel
    {
        #region Atributos
        private string _logradouro;
        private string _numero;
        private string _complemento;
        private string _bairro;
        private string _cidade;
        private string _uf;
        private string _cep;
        #endregion


        #region Propriedades
        public string Logradouro
        {
            get { return _logradouro; }
            set { SetProperty(ref _logradouro, value); }
        }
        public string Numero
        {
            get { return _numero; }
            set { SetProperty(ref _numero, value); }
        }
        public string Complemento
        {
            get { return _complemento; }
            set { SetProperty(ref _complemento, value); }
        }
        public string Bairro
        {
            get { return _bairro; }
            set { SetProperty(ref _bairro, value); }
        }
        public string Cidade
        {
            get { return _cidade; }
            set { SetProperty(ref _cidade, value); }
        }
        public string UF
        {
            get { return _uf; }
            set { SetProperty(ref _uf, value); }
        }
        public string Cep
        {
            get { return _cep; }
            set { SetProperty(ref _cep, value); }
        }
        #endregion
    }
}
