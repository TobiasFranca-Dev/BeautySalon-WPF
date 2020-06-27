using System;

namespace BeautySalon.Models
{
    public class Cliente : BaseModel
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public Endereco Endereco { get; set; }
        public string Celular { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }

        public Usuario Usuario { get; set; }
    }
}
