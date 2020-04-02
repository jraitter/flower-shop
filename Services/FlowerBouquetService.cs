using System;
using System.Collections.Generic;
using mysql.Models;
using mysql.Repository;

namespace mysql.Services
{
  public class FlowerBouquetService
  {
    private readonly FlowerBouquetsRepository _repo;

    public FlowerBouquetService(FlowerBouquetsRepository repo)
    {
      _repo = repo;
    }

    //get
    internal IEnumerable<FlowerBouquet> Get()
    {
      return _repo.Get();
    }

    //Get by id
    internal FlowerBouquet Get(int id)
    {
      FlowerBouquet found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }

    //create/post
    internal FlowerBouquet Create(FlowerBouquet newFlowerBouquet)
    {
      FlowerBouquet created = _repo.Create(newFlowerBouquet);
      if (created == null)
      {
        throw new Exception("Create Request Failed");
      }
      return created;
    }

    //edit/put
    internal FlowerBouquet Edit(FlowerBouquet updatedFlowerBouquet)
    {
      FlowerBouquet found = Get(updatedFlowerBouquet.Id);
      found.FlowerId = updatedFlowerBouquet.FlowerId;
      found.BouquetId = updatedFlowerBouquet.BouquetId;
      return _repo.Edit(found);
    }

    //delete
    internal string Delete(int id)
    {
      if (_repo.Delete(id))
      {
        return "Successfully Deleted";
      }
      throw new Exception("Invalid Id");
    }

  }
}