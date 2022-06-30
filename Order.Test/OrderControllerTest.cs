using CSharp.Controllers;
using CSharp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace Order.Test
{
    public class OrderControllerTest
    {
        OrderController _controller;
        OrderService _service;

        public OrderControllerTest()
        {
            //_service = new OrderService();
            //_controller = new OrderController();
        }

        [Fact]
        public void GetAllTest()
        {
            var result = _controller.GetAll();
            Assert.IsType<OkObjectResult>(result.Result);
            var list = result.Result as OkObjectResult;
            Assert.NotNull(list);
        }
    }
}
