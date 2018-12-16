using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainValidationExamples.Repositories;
using DomainValidationExamples.Validations;
using Microsoft.AspNetCore.Mvc;

namespace DomainValidationExamples.Controllers
{
    public class OrdersMVCController : Controller
    {
        private readonly IOrderValidation _orderValidation;
        private readonly IOrderRepository _orderRepository;

        public OrdersMVCController(
            IOrderValidation orderValidation)
        {
            _orderValidation = orderValidation;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(object request)
        {
            //if (!_orderValidation.IsValid(value, out List<string> errors))
            if (!OrderRequestIsValid(request))
            {
                return View();
            }

            //OrderRepository orderRepository = new OrderRepository();
            _orderRepository.Save();

            return View();
        }

        private bool OrderRequestIsValid(object request)
        {
            return false;
        }
    }
}