using System.Collections.Generic;
using System.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using mysql.Models;

namespace mysql.Repository
{
  public class FlowersRepository
  {
    private readonly IDbConnection _db;

    // dependency injection: repository depends on db connection
    public FlowersRepository(IDbConnection db)
    {
      _db = db;
    }
    //Get
    internal IEnumerable<Flower> Get()
    {
      string sql = @"SELECT * FROM flowers";
      return _db.Query<Flower>(sql);
    }

    //GetById
    internal Flower Get(int Id)
    {
      string sql = @"SELECT * FROM flowers WHERE id = @Id";
      return _db.QueryFirstOrDefault<Flower>(sql, new { Id });
    }
    //Post
    internal Flower Create(Flower newFlower)
    {
      string sql = @"
      INSERT INTO flowers (name, price)
      VALUES (@Name, @Price);
      SELECT LAST_INSERT_ID();
      ";
      newFlower.Id = _db.ExecuteScalar<int>(sql, newFlower);
      return newFlower;
    }
    //Put
    internal Flower Edit(Flower updateFlower)
    {
      string sql = @"
      UPDATE flowers SET 
        name = @Name,
        price = @Price
      WHERE id = @Id
      ";
      _db.Execute(sql, updateFlower);
      return updateFlower;
    }
    //Delete
    internal bool Delete(int Id)
    {
      string sql = @"DELETE FROM flowers WHERE id = @Id LIMIT 1";
      int removed = _db.Execute(sql, new { Id });
      return removed == 1;
    }
  }
}