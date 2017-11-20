using Dominio.Interface.Servico;
using Dominio.Interfaces.Repositorio;
using System.Collections.Generic;

namespace Dominio.Servicos
{
    public class ServicoBase<TEntity> : IServicoBase<TEntity> where TEntity : class
    {
        private readonly IRepositorioBase<TEntity> _repositorioBase;

        public ServicoBase(IRepositorioBase<TEntity> repositorioBase)
        {
            _repositorioBase = repositorioBase;
        }

        public TEntity Inserir(TEntity entidade)
        {
            return _repositorioBase.Inserir(entidade);
        }

        public void Atualizar(TEntity entidade)
        {
            _repositorioBase.Atualizar(entidade);
        }

        public void Excluir(string id)
        {
            _repositorioBase.Excluir(id);
        }

        public TEntity ObterPorId(string id)
        {
            return _repositorioBase.ObterPorId(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return _repositorioBase.ObterTodos();
        }   
    }
}