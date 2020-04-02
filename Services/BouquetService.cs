using System;
using System.Collections.Generic;
using mysql.Models;
using mysql.Repository;

namespace mysql.Services
{
  public class BouquetService
  {
    private readonly BouquetsRepository _repo;

    public BouquetService(BouquetsRepository repo)
    {
      _repo = repo;
    }

    //get
    internal IEnumerable<Bouquet> Get()
    {
      return _repo.Get();
    }

    //Get by id
    internal Bouquet Get(int id)
    {
      Bouquet found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }

    //create/post
    internal Bouquet Create(Bouquet newBouquet)
    {
      Bouquet created = _repo.Create(newBouquet);
      if (created == null)
      {
        throw new Exception("Create Request Failed");
      }
      return created;
    }

    //edit/put
    internal Bouquet Edit(Bouquet updatedBouquet)
    {
      Bouquet found = Get(updatedBouquet.Id);
      found.Name = updatedBouquet.Name;
      found.Description = updatedBouquet.Description != null ? updatedBouquet.Description : found.Description;
      found.Price = updatedBouquet.Price != 0 ? updatedBouquet.Price : found.Price;
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