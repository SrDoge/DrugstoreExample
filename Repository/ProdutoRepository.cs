using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DrugstoreExemple.Entities;
using Microsoft.Extensions.Configuration;

namespace DrugstoreExemple.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly IConfiguration _conf;

        public ProdutoRepository(IConfiguration configuration)
        {
            _conf = configuration;
        }

        public string GetConnection()
        {
            var connection = _conf.GetSection("ConnectionsStrings").GetSection("ProdutoConnection").Value;
            Console.WriteLine("Pegando a String de conexão...");
            return connection;
        }

        public void AddProduto(Produto produto)
        {
            var connectionString = this.GetConnection();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "Insert into dbo.crud_ProdutoFar (Nome, Descricao, Preco, Qtde) Values(@Nome, @Descricao, @Preco, @Qtde)";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Nome", produto.Nome);
                cmd.Parameters.AddWithValue("@Cidade", produto.Descricao);
                cmd.Parameters.AddWithValue("@Departamento", produto.Preco);
                cmd.Parameters.AddWithValue("@Sexo", produto.Qtde);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteProduto(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> GetAllProdutos()
        {
            var connectionString = this.GetConnection();
            var lstproduto = new List<Produto>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.crud_ProdutoFar", con);
                cmd.CommandType = CommandType.Text;

                con.Open();
                Console.WriteLine("Abrindo conexão com banco...");
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Produto produto = new Produto();
                    produto.ProdID = Convert.ToInt32(rdr["ProdID"]);
                    produto.Nome = rdr["Nome"].ToString();
                    produto.Descricao = rdr["Descricao"].ToString();
                    produto.Preco = Convert.ToDecimal(rdr["Preco"]);
                    produto.Qtde = Convert.ToInt32(rdr["Qtde"]);
                    lstproduto.Add(produto);
                }
                con.Close();
                Console.WriteLine("Fechando conexão com banco...");
            }
            return lstproduto;
        }

        public Produto GetProduto(int id)
        {
            var connectionString = this.GetConnection();
            Produto produto = new Produto();
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                string sqlQuery = "SELECT * FROM dbo.crud_ProdutoFar WHERE ProdID = " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                cmd.CommandType = CommandType.Text;

                con.Open();
                Console.WriteLine("Abrindo conexão com banco...");
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    produto.ProdID = Convert.ToInt32(rdr["ProdID"]);
                    produto.Nome = rdr["Nome"].ToString();
                    produto.Descricao = rdr["Descricao"].ToString();
                    produto.Preco = Convert.ToDecimal(rdr["Preco"]);
                    produto.Qtde = Convert.ToInt32(rdr["Qtde"]);
                }
                con.Close();
                Console.WriteLine("Fechando conexão com banco...");
            }
            return produto;
        }
        

        public void UpdateProduto(Produto produto)
        {
            throw new NotImplementedException();
        }
    }
}
