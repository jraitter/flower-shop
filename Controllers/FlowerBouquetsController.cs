using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using mysql.Models;
using mysql.Services;

namespace mysql.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class FlowerBouquetsController : ControllerBase
  {
    private readonly FlowerBouquetService _fbs;

    // dependency: controller depends on service
    public FlowerBouquetsController(FlowerBouquetService fbs)
    {
      _fbs = fbs;
    }

    [HttpGet]
    public ActionResult<IEnumerable<FlowerBouquet>> Get()
    {
      try
      {
        return Ok(_fbs.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<FlowerBouquet> Get(int id)
    {
      try
      {
        return Ok(_fbs.Get(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<FlowerBouquet> Create([FromBody] FlowerBouquet newFlowerBouquet)
    {
      try
      {
        return Ok(_fbs.Create(newFlowerBouquet));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<FlowerBouquet> Edit(int id, [FromBody] FlowerBouquet updatedFlowerBouquet)
    {
      try
      {
        updatedFlowerBouquet.Id = id;
        return Ok(_fbs.Edit(updatedFlowerBouquet));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<FlowerBouquet> Delete(int id)
    {
      try
      {
        return Ok(_fbs.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}