using Dominio.Interfaces.Repositorio;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Infraestrutura.Repositorios
{
    public class RepositorioBase<TEntity> : IRepositorioBase<TEntity> where TEntity : class
    {
        protected IMongoDatabase bancoDeDados;
        protected IMongoCollection<TEntity> colecao;

        public RepositorioBase()
        {
            var conexaoCIM = ConfigurationManager.ConnectionStrings["conexaoCIMlocal"].ConnectionString;

            var cliente = new MongoClient(conexaoCIM);

            bancoDeDados = cliente.GetDatabase("BDCIM");

            colecao = bancoDeDados.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public TEntity Inserir(TEntity entidade)
        {
            try
            {
                colecao.InsertOneAsync(entidade);

                return entidade;
            }
            catch (Exception ex)
            {
                throw new Exception("RepositorioBase: Erro ao inserir dados. ", ex);
            }
        }

        public void Atualizar(TEntity entidade)
        {
            try
            {
                var filtro = ObterFiltroPorId(entidade);

                colecao.ReplaceOneAsync(filtro, entidade);
            }
            catch (Exception ex)
            {
                throw new Exception("RepositorioBase: Erro ao alterar dados. ", ex);
            }
        }

        public void Excluir(string id)
        {
            try
            {
                var filtro = ObterFiltroPorId(id);

                colecao.DeleteOneAsync(filtro);
            }
            catch (Exception ex)
            {
                throw new Exception("RepositorioBase: Erro ao excluir dados. ", ex);
            }
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            try
            {
                return colecao.AsQueryable();
            }
            catch (Exception ex)
            {
                throw new Exception("RepositorioBase: Erro ao obter todos os dados. ", ex);
            }
        }

        public TEntity ObterPorId(string id)
        {
            try
            {
                var filtro = ObterFiltroPorId(id);

                return colecao.Find(filtro).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("RepositorioBase: Erro ao obter o equipamento " + id, ex);
            }
        }

        private FilterDefinition<TEntity> ObterFiltroPorId(TEntity entidade)
        {
            try
            {
                var valor = typeof(TEntity).GetProperties().FirstOrDefault(x => x.Name == "Id").GetValue(entidade).ToString();

                return ObterFiltroPorId(valor);
            }
            catch (Exception ex)
            {
                throw new Exception("RepositorioBase: Erro ao obter filtro por ID", ex);
            }
        }

        private FilterDefinition<TEntity> ObterFiltroPorId(string id)
        {
            try
            {
                return Builders<TEntity>.Filter.Eq("_id", ObjectId.Parse(id));
            }
            catch (FormatException fe)
            {
                throw new FormatException("RepositorioBase: O ID não está em um formato correto", fe);
            }
        }
    }
}