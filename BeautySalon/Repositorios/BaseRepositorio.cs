using BeautySalon.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeautySalon.Repositorios
{
    public abstract class BaseRepositorio<T> where T : BaseModel
    {
        public virtual int Cadastrar(T item)
        {
            using (var db = new LiteDatabase(Shared.DatabaseName))
            {
                var col = db.GetCollection<T>(typeof(T).Name);

                item.DataCadastro = DateTime.Now;
                item.DataUltimaAlteracao = DateTime.Now;

                col.Insert(item);
                return item.Id;
            }
        }

        public virtual void Atualizar(T item)
        {
            using (var db = new LiteDatabase(Shared.DatabaseName))
            {
                var col = db.GetCollection<T>(typeof(T).Name);

                item.DataUltimaAlteracao = DateTime.Now;

                col.Update(item);
            }
        }

        public virtual void Excluir(T item)
        {
            using (var db = new LiteDatabase(Shared.DatabaseName))
            {
                var col = db.GetCollection<T>(typeof(T).Name);

                col.Delete(item.Id);
            }
        }

        public virtual List<T> ListarTodos()
        {
            using (var db = new LiteDatabase(Shared.DatabaseName))
            {
                var col = db.GetCollection<T>(typeof(T).Name);
                return col.FindAll().ToList();
            }
        }

        public virtual T BuscarPorId(int id)
        {
            using (var db = new LiteDatabase(Shared.DatabaseName))
            {
                var col = db.GetCollection<T>(typeof(T).Name);
                return col.FindById(id);
            }
        }
    }
}
