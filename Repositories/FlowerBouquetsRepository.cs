using System.Collections.Generic;
using System.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using mysql.Models;

namespace mysql.Repository
{
  public class FlowerBouquetsRepository
  {
    private readonly IDbConnection _db;

    public FlowerBouquetsRepository(IDbConnection db)
    {
      _db = db;
    }
    //Get
    internal IEnumerable<FlowerBouquet> Get()
    {
      string sql = @"SELECT * FROM flowerbouquets";
      return _db.Query<FlowerBouquet>(sql);
    }

    //GetById
    internal FlowerBouquet Get(int Id)
    {
      string sql = @"SELECT * FROM flowerbouquets WHERE id = @Id";
      return _db.QueryFirstOrDefault<FlowerBouquet>(sql, new { Id });
    }
    //Post
    internal FlowerBouquet Create(FlowerBouquet newFlowerBouquet)
    {
      string sql = @"
      INSERT INTO flowerbouquets (flowerId, bouquetId)
      VALUES (@FlowerId, @BouquetId);
      SELECT LAST_INSERT_ID();
      ";
      newFlowerBouquet.Id = _db.ExecuteScalar<int>(sql, newFlowerBouquet);
      return newFlowerBouquet;
    }
    //Put
    internal FlowerBouquet Edit(FlowerBouquet updateFlowerBouquet)
    {
      string sql = @"
      UPDATE flowerbouquets SET 
        flowerId = @FlowerId,
        bouquetId = @BouquetId
      WHERE id = @Id
      ";
      _db.Execute(sql, updateFlowerBouquet);
      return updateFlowerBouquet;
    }
    //Delete
    internal bool Delete(int Id)
    {
      string sql = @"DELETE FROM flowerbouquets WHERE id = @Id LIMIT 1";
      int removed = _db.Execute(sql, new { Id });
      return removed == 1;
    }
  }
}