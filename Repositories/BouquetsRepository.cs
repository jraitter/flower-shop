using System.Collections.Generic;
using System.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using mysql.Models;

namespace mysql.Repository
{
  public class BouquetsRepository
  {
    private readonly IDbConnection _db;

    public BouquetsRepository(IDbConnection db)
    {
      _db = db;
    }
    //Get
    internal IEnumerable<Bouquet> Get()
    {
      string sql = @"SELECT * FROM bouquets";
      return _db.Query<Bouquet>(sql);
    }

    //GetById
    internal Bouquet Get(int Id)
    {
      string sql = @"SELECT * FROM bouquets WHERE id = @Id";
      return _db.QueryFirstOrDefault<Bouquet>(sql, new { Id });
    }
    //Post
    internal Bouquet Create(Bouquet newBouquet)
    {
      string sql = @"
      INSERT INTO bouquets (name, description, price)
      VALUES (@Name, @Description, @Price);
      SELECT LAST_INSERT_ID();
      ";
      newBouquet.Id = _db.ExecuteScalar<int>(sql, newBouquet);
      return newBouquet;
    }
    //Put
    internal Bouquet Edit(Bouquet updateBouquet)
    {
      string sql = @"
      UPDATE bouquets SET 
        name = @Name,
        description = @Description,
        price = @price
      WHERE id = @Id
      ";
      _db.Execute(sql, updateBouquet);
      return updateBouquet;
    }
    //Delete
    internal bool Delete(int Id)
    {
      string sql = @"DELETE FROM bouquets WHERE id = @Id LIMIT 1";
      int removed = _db.Execute(sql, new { Id });
      return removed == 1;
    }
  }
}