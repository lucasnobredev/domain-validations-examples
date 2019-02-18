using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainValidationExamples.Domain;
using DomainValidationExamples.DTOs;
using DomainValidationExamples.Repositories;
using DomainValidationExamples.Validations;
using Microsoft.AspNetCore.Mvc;

namespace DomainValidationExamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersAPIController : ControllerBase
    {
        private readonly IOrderValidation _orderValidation;
        private readonly IOrderRepository _orderRepository;

        public OrdersAPIController(
            IOrderValidation orderValidation,
            IOrderRepository orderRepository)
        {
            _orderValidation = orderValidation;
            _orderRepository = orderRepository;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] OrderRequest request)
        {
            if (_orderValidation.IsValid(request, out List<string> errors) == false)
            {
                return BadRequest(errors);
            }

            var order = MapOrderByRequest(request);

            _orderRepository.Save(order);

            return Ok();
        }

        [HttpPost]
        public IActionResult PostWithValidationInDomain([FromBody] OrderRequest request)
        {
            var order = Order.CreateOrder(request);

            if(order.IsValid() == false)
            {
                return BadRequest();
            }

            _orderRepository.Save(order);

            return Ok();
        }

        [HttpPost]
        public IActionResult PostWithValidationInConstructionOfDomain([FromBody] OrderRequest request)
        {
            if (Order.CanCreateOrder(request, out Order order) == false)
            {
                return BadRequest();
            }

            _orderRepository.Save(order);

            return Ok();
        }


        private object MapOrderByRequest(object request)
        {
            throw new NotImplementedException();
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}
