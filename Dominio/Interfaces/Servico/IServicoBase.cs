﻿using System.Collections.Generic;

namespace Dominio.Interface.Servico
{
    public interface IServicoBase<TEntity> where TEntity : class
    {
        TEntity Inserir(TEntity entidade);
        void Atualizar(TEntity entidade);
        void Excluir(string id);
        TEntity ObterPorId(string id);
        IEnumerable<TEntity> ObterTodos();
    }
}
