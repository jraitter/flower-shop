using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using mysql.Models;
using mysql.Services;

namespace mysql.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class FlowersController : ControllerBase
  {
    private readonly FlowerService _fs;

    public FlowersController(FlowerService fs)
    {
      _fs = fs;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Flower>> Get()
    {
      try
      {
        return Ok(_fs.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Flower> Get(int id)
    {
      try
      {
        return Ok(_fs.Get(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Flower> Create([FromBody] Flower newFlower)
    {
      try
      {
        return Ok(_fs.Create(newFlower));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Flower> Edit(int id, [FromBody] Flower updatedFlower)
    {
      try
      {
        updatedFlower.Id = id;
        return Ok(_fs.Edit(updatedFlower));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<Flower> Delete(int id)
    {
      try
      {
        return Ok(_fs.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}