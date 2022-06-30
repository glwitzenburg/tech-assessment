using CSharp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace Order.Test
{
    public class OrderControllerTest
    {
        OrdersController _controller;
        OrdersService _service;

        public OrderControllerTest()
        {
            _service = new OrdersService();
            _controller = new OrdersController(_service);
        }

        [Fact]
        public void GetAllTest()
        {
            var result = _controller.Get();
            Assert.IsType<OkObjectResult>(result.Result);
            var list = result.Result as OkObjectResult;
            Assert.NotNull(list);
        }

        [Fact]
        public void GetOrderByIdTest()
        {
            var invalidId = 10;
            var validId = 2;

            var notFoundResult = _controller.Get(invalidId);
            var foundResult = _controller.Get(validId);

            Assert.IsType<NotFoundResult>(notFoundResult.Result);
            Assert.IsType<OkObjectResult>(foundResult.Result);
        }

        [Fact]
        public void AddOrderTest()
        {
            var newOrder = new Orders()
            {
                Id = 8,
                Name = "test3",
                Price = 7.00,
                Cancelled = false
            };

            var createResponse = _controller.CreateOrder(newOrder);

            Assert.IsType<CreatedAtActionResult>(createResponse);
        }

        [Fact]
        public void CancelOrderTest()
        {

            var newOrder = new Orders()
            {
                Id = 5,
                Name = "test3",
                Price = 7.00,
                Cancelled = true
            };

            var createResponse = _controller.Cancel(5);
            var item = createResponse as CreatedAtActionResult;
            Assert.True(newOrder.Cancelled);
        }


    }
}
