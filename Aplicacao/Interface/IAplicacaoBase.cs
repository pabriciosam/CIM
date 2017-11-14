using System.Collections.Generic;

namespace Aplicacao.Interface
{
    public interface IAplicacaoBase<TEntity> where TEntity : class
    {
        void Add(TEntity entidade);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
    }
}
