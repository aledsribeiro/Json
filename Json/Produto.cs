using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    /// <summary>
    /// quando se tem menos propriedades para serializar
    /// colocammos o atributo DataContract na classe e nas propriedades
    /// colocamos o DataMember
    /// quando se tem poucas propriedades que não se deve serializar
    /// podemos apenas usar o atributo JsonIgnore
    /// </summary>
    [DataContract]
    public class Produto
    {
        [DataMember]
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        //quando essa classe for serializada as propriedades que possuem o atributo
        //não serão serializadas
        [JsonIgnore]
        public DateTime DataCadastro { get; set; }
        public decimal PrecoCusto { get; set; }
        public string DescricaoEtiqueta { get; set; }

        public Produto(int codigo, string nome, decimal preco)
        {
            this.Codigo = codigo;
            this.Nome = nome;
            this.Preco = preco;
        }

        public override string ToString()
        {
            return $"{Codigo} - { Nome} - {Preco}";
        }
    }
}
