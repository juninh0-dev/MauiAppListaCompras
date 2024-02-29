using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using MauiAppListaCompras.Models;

namespace MauiAppListaCompras.Helpers
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;

        public SQLiteDatabaseHelper(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Produto>().Wait();
        }

        public Task<int> Insert(Produto p)
        {
            return _conn.InsertAsync(p);
        }

        public Task<List<Produto>> Update(Produto p) 
        {
            string sql = "Update Produto SET Descricao=?, Preco=?, Quantidade, WHERE id=?";

            return _conn.QueryAsync<Produto>(sql, p.Descricao, p.Preco, p.Quantidade, p.Id);
        }


        public Task<int> Delelte(int id)
        {
            return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);
        }

    }
}
