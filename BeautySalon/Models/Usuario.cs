namespace BeautySalon.Models
{
    public class Usuario : BaseModel
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }

        public bool Desenvolvedor { get; set; }

        /* Permissões de clientes*/
        public bool AcessaClientes { get; set; }
        public bool CadastraCliente { get; set; }
        public bool EditaCliente { get; set; }
        public bool ExcluiCliente { get; set; }

    }
}
