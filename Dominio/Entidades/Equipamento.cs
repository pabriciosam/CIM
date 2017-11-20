using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Equipamento
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int? Andar { get; set; }
        public string TipoEquipamento { get; set; }
        public bool StatusAcesso { get; set; }
        public List<string> EquipamentosAcessados { get; set; }

        public Equipamento()
        {
            this.EquipamentosAcessados = new List<string>();
        }

        public bool PossuiNome()
        {
            return !string.IsNullOrWhiteSpace(this.Nome);
        }

        public bool PossuiTipoEquipamento()
        {
            return !string.IsNullOrWhiteSpace(this.TipoEquipamento);
        }
    }
}