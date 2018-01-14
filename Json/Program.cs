using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    class Program
    {
        static void Main(string[] args)
        {
            //ConverterObjetoEmJson();
            //ConverterJsonEmObjeto();
            SalvarObjetoEmArquivo();
            //LerObjetoDeArquivo();
        }

        static void ConverterObjetoEmJson()
        {
            Topico topico = new Topico()
            {

                Id = 1,
                Titulo = "teste",
                Conteudo = "Json",
                Usuario="alessandra",
                Tags =  new string[3] { "ASP Net", "C#", "Visual Studio"}
            };

            string json = JsonConvert.SerializeObject(topico);

            Console.WriteLine(json);
            Console.ReadKey();
           
        }

        static void ConverterJsonEmObjeto()
        {
            string json = "{" + 
                "'Id':1,"+
                "'Titulo':'teste'," +
                "'Conteudo':'Json'," +
                "'Usuario':'alessandra'," +
                "Tags:['ASP Net','C#','Visual Studio']"+
                "}";

            Topico topico = JsonConvert.DeserializeObject<Topico>(json);

            //imprmimos algumas das propriedades do objeto convertido
            //********foi usado string interpolation
            Console.WriteLine($"{topico.Id}\n{topico.Titulo}\n{topico.Conteudo}");
            Console.ReadKey();
        }

        static void SalvarObjetoEmArquivo()
        {
            List<Produto> listaProdutos = CriarListaProdutos();
           

            StreamWriter stream = new StreamWriter("C:\\Users\\aleds\\Documents\\Json\\Produtos.json");

            //responsavel por escrever o conteudo dos objetos em um stream
            JsonTextWriter writer = new JsonTextWriter(stream);

            //para formatar os arquivos - paraa casos onde não for tragefar os dados
            writer.Formatting = Formatting.Indented;

            //faz de fato a serialização
            JsonSerializer serializer = new JsonSerializer();

            //não serializa as propriedades nulas
            //serializer.NullValueHandling = NullValueHandling.Ignore;

            //sempre que encontrar uma propriedade com valor default como
            //por exemplo um datetime = 01/01/0001
            //serializer.DefaultValueHandling = DefaultValueHandling.Ignore;

            

            serializer.Serialize(writer, listaProdutos);

            stream.Close();
        }

        static void LerObjetoDeArquivo()
        {
            StreamReader stream = new StreamReader("C:\\Users\\aleds\\Documents\\Json\\Produtos.json");
            JsonTextReader reader = new JsonTextReader(stream);
            JsonSerializer serializer = new JsonSerializer();

            List<Produto> produtos = serializer.Deserialize<List<Produto>>(reader);

            foreach (var item in produtos)
            {
                Console.WriteLine(item);
            }

            stream.Close();
            Console.ReadKey();
        }

        //feito para testar a redução do arquivo
        static List<Produto> CriarListaProdutos()
        {
            List<Produto> produtos = new List<Produto>();

            for (int i = 0; i < 1000; i++)
            {
                produtos.Add(new Produto(i + 1, $"Produto{i + 1}", (i + 1) * 5)
                {
                    DataCadastro = DateTime.Now.AddDays(-1),
                    PrecoCusto = i * 3
                });
            }

            return produtos;
        }
    }
}
