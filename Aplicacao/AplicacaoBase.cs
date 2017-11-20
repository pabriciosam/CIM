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

        public TEntity Inserir(TEntity entidade)
        {
            return _servicoBase.Inserir(entidade);
        }

        public void Atualizar(TEntity entidade)
        {
            _servicoBase.Atualizar(entidade);
        }

        public void Excluir(string id)
        {
            _servicoBase.Excluir(id);
        }

        public TEntity ObterPorId(string id)
        {
            return _servicoBase.ObterPorId(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return _servicoBase.ObterTodos();
        }
    }
}