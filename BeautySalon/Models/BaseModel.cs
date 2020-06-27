using LiteDB;
using System;

namespace BeautySalon.Models
{
    public abstract class BaseModel
    {
        [BsonId]
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }

    }
}
