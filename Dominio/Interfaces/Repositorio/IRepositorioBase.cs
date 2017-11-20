using System.Collections.Generic;

namespace Dominio.Interfaces.Repositorio
{
    public interface IRepositorioBase<TEntity> where TEntity : class
    {
        TEntity Inserir(TEntity entidade);
        void Atualizar(TEntity entidade);
        void Excluir(string id);
        TEntity ObterPorId(string id);
        IEnumerable<TEntity> ObterTodos();
    }
}
