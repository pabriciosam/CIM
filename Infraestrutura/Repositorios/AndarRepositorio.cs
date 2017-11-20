using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using MongoDB.Driver;

namespace Infraestrutura.Repositorios
{
    public class AndarRepositorio : RepositorioBase<Andar>, IAndarRepositorio
    {
        public Andar ObterAndarPorNumero(int Numero)
        {
            var filtro = Builders<Andar>.Filter.Eq("Numero", Numero);

            return colecao.Find(filtro).FirstOrDefault();
        }
    }
}