using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainValidationExamples.Validations;
using Microsoft.AspNetCore.Mvc;

namespace DomainValidationExamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersAPIController : ControllerBase
    {
        private readonly IOrderValidation _orderValidation;

        public OrdersAPIController(
            IOrderValidation orderValidation)
        {
            _orderValidation = orderValidation;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            //if(OrderRequestIsValid(value))
            if (!_orderValidation.IsValid(value, out List<string> errors))
            {
                return BadRequest(errors);
            }

            return Ok();
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}
