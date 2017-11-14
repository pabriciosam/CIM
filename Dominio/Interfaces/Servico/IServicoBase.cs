using System.Collections.Generic;

namespace Dominio.Interface.Servico
{
    public interface IServicoBase<TEntity> where TEntity : class
    {
        void Add(TEntity entidade);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
    }
}
