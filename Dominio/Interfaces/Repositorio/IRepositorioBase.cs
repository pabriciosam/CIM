using System.Collections.Generic;

namespace Dominio.Interfaces.Repositorio
{
    public interface IRepositorioBase<TEntity> where TEntity : class
    {
        void Add(TEntity entidade);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
    }
}
