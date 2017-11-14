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

        public TEntity GetById(int id)
        {
            return _repositorioBase.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repositorioBase.GetAll();
        }

        public void Add(TEntity entidade)
        {
            _repositorioBase.Add(entidade);
        }
    }
}