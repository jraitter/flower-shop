using System;
using System.Collections.Generic;
using mysql.Models;
using mysql.Repository;

namespace mysql.Services
{
  public class FlowerService
  {
    private readonly FlowersRepository _repo;

    // injection dependency: service depends on repository
    public FlowerService(FlowersRepository repo)
    {
      _repo = repo;
    }

    //get
    internal IEnumerable<Flower> Get()
    {
      return _repo.Get();
    }

    //Get by id
    internal Flower Get(int id)
    {
      Flower found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }

    //create/post
    internal Flower Create(Flower newFlower)
    {
      Flower created = _repo.Create(newFlower);
      if (created == null)
      {
        throw new Exception("Create Request Failed");
      }
      return created;
    }

    //edit/put
    internal Flower Edit(Flower updatedFlower)
    {
      Flower found = Get(updatedFlower.Id);
      found.Name = updatedFlower.Name;
      found.Price = updatedFlower.Price != 0 ? updatedFlower.Price : found.Price;
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