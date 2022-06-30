using System;
using System.Linq;
using CSharp.Models;
using Microsoft.AspNetCore.Mvc;
using CSharp.Services;
using System.Collections.Generic;

namespace CSharp.Controllers
{

	[ApiController]
	[Route("[controller]")]
	public class OrderController : ControllerBase
	{

		[HttpGet]
		public ActionResult<List<Order>> GetAll() =>
		OrderService.GetAll();

		[HttpGet("{id}")]
		public ActionResult<Order> Get(int id)
		{
			var order = OrderService.Get(id);

			if (order == null)
				return NotFound();

			return order;
		}

		[HttpPost]
		public IActionResult CreateOrder(Order order)
		{
			OrderService.Add(order);
			return CreatedAtAction(nameof(CreateOrder), new { id = order.Id }, order);
		}

		[HttpPut("{id}")]
		public IActionResult UpdateOrder(int id, Order order)
		{
			if (id != order.Id)
				return BadRequest();

			var existingOrder = OrderService.Get(id);
			if (existingOrder is null)
				return NotFound();

			OrderService.Update(order);

			return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteOrder(int id)
		{
			var order = OrderService.Get(id);

			if (order is null)
				return NotFound();

			OrderService.Delete(id);

			return NoContent();
		}
	}
}
