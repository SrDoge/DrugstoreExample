using System;
using System.Collections.Generic;
using System.Text;
using DrugstoreExemple.Entities;

namespace DrugstoreExemple.Repository
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> GetAllProdutos();
        void AddProduto(Produto produto);
        void UpdateProduto(Produto produto);
        Produto GetProduto(int id);
        void DeleteProduto(int id);
    }
}
