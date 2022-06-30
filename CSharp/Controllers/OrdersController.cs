
using CSharp.Interfaces;
using CSharp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

[Route("[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrdersService _service;

    public OrdersController(IOrdersService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Orders>> Get()
    {
        var items = _service.GetAll();
        return Ok(items);
    }

    [HttpGet("{id}")]
    public ActionResult<Orders> Get(int id)
    {
        var item = _service.GetById(id);

        if (item == null)
        {
            return NotFound();
        }

        return Ok(item);
    }

    [HttpPost]
    public ActionResult CreateOrder([FromBody] Orders order)
    {
        _service.Add(order);
        return CreatedAtAction(nameof(CreateOrder), new { id = order.Id }, order);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateOrder(int id, Orders order)
    {
        if (id != order.Id)
            return BadRequest();

        var existingOrder = _service.GetById(id);
        if (existingOrder is null)
            return NotFound();

        _service.Update(order);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Cancel(int id)
    {
        var existingItem = _service.GetById(id);

        if (existingItem == null)
        {
            return NotFound();
        }

        _service.Cancel(id);
        return Ok();
    }
}