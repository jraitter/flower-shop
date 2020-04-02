using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using mysql.Models;
using mysql.Services;

namespace mysql.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BouquetsController : ControllerBase
  {
    private readonly BouquetService _bs;

    public BouquetsController(BouquetService bs)
    {
      _bs = bs;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Bouquet>> Get()
    {
      try
      {
        return Ok(_bs.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Bouquet> Get(int id)
    {
      try
      {
        return Ok(_bs.Get(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Bouquet> Create([FromBody] Bouquet newBouquet)
    {
      try
      {
        return Ok(_bs.Create(newBouquet));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Bouquet> Edit(int id, [FromBody] Bouquet updatedBouquet)
    {
      try
      {
        updatedBouquet.Id = id;
        return Ok(_bs.Edit(updatedBouquet));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<Bouquet> Delete(int id)
    {
      try
      {
        return Ok(_bs.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}