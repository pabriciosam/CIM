using Aplicacao.Interface;
using Dominio.Interface.Servico;
using System.Collections.Generic;

namespace Aplicacao
{
    public class AplicacaoBase<TEntity> : IAplicacaoBase<TEntity> where TEntity : class
    {
        private readonly IServicoBase<TEntity> _servicoBase;

        public AplicacaoBase(IServicoBase<TEntity> servicoBase)
        {
            _servicoBase = servicoBase;
        }

        public TEntity GetById(int id)
        {
            return _servicoBase.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _servicoBase.GetAll();
        }

        public void Add(TEntity entidade)
        {
            _servicoBase.Add(entidade);
        }
    }
}