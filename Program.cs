using System;
using DrugstoreExemple.Repository;
using DrugstoreExemple.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace DrugstoreExemple
{
    class Program
    {
        private static IProdutoRepository _produto;
        public static IConfigurationRoot _Configuration;

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json");
            _Configuration = builder.Build();

            _produto = new ProdutoRepository(_Configuration);



            var lista = _produto.GetAllProdutos();

            foreach (var objProd in lista)
            {
                Console.WriteLine("Nome do Produto: " + objProd.Nome);
            }

            Console.Write("Informe o ID do produto: ");
            int id = int.Parse(Console.ReadLine());

            var idprod = _produto.GetProduto(id);

            if (idprod.ProdID == id)
            {
                Console.WriteLine("ID do Produto: " + idprod.ProdID);
                Console.WriteLine("Nome: " + idprod.Nome);
                Console.WriteLine("Descrição: " + idprod.Descricao);
                Console.WriteLine("Preço: " + idprod.Preco.ToString("C2"));
                Console.WriteLine("Quantidade no estoque: " + idprod.Qtde);
            }
            else
            {
                Console.WriteLine("ID Incorreto!");
            }
        }
    }
}
