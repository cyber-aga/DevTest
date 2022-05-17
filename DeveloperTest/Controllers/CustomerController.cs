using DeveloperTest.Business.Interfaces;
using DeveloperTest.Models;
using DeveloperTest.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace DeveloperTest.Controllers
{
    [ApiController, Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.customerService.GetCustomers());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(this.customerService.GetCustomer(id));
        }

        [HttpGet("types")]
        [Route("{controller}/types")]
        public IActionResult GetTypes()
        {
            return Ok(Enum.GetNames(typeof(CustomerType)));
        }

        [HttpPost]
        public IActionResult Post([FromBody] BaseCustomerModel customer)
        {
            var created = this.customerService.CreateCustomer(customer);
            return Created($"customer/{created.Id}", created);
        }

    }
}
