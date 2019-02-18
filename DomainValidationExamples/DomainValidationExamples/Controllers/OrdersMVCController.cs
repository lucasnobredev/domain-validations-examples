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
        public IActionResult Index(OrderViewModel request)
        {            
            if (OrderRequestIsValid(request) == false)
            {
                return View();
            }

            var order = MapOrderByRequest(request); 

            _orderRepository.Save(order);

            return View();
        }

        [HttpPost]
        public IActionResult IndexWithValidationEncapsulated(OrderViewModel request)
        {
            if (_orderValidation.IsValid(request, out List<string> errors) == false)
            {
                return View();
            }

            var order = MapOrderByRequest(request);

            _orderRepository.Save(order);

            return View();
        }

        [HttpPost]
        public IActionResult IndexWithValidationInDomain(OrderViewModel request)
        {
            var order = Order.CreateOrder(request);

            if (order.IsValid() == false)
            {
                return View();
            }

            _orderRepository.Save(order);

            return View();
        }

        [HttpPost]
        public IActionResult IndexWithValidationInConstructionOfDomain(OrderViewModel request)
        {
            if(Order.CanCreateOrder(request, out Order order) == false)
            {
                return View();
            }
            
            _orderRepository.Save(order);
        
            return View();
        }

        private Order MapOrderByRequest(object request)
        {
            throw new NotImplementedException();
        }
        
        private bool OrderRequestIsValid(OrderViewModel request)
        {
            if (string.IsNullOrEmpty(request.FirstName) || request.FirstName.Length > 100)
                return false;

            if (string.IsNullOrEmpty(request.LastName) || request.LastName.Length > 150)
                return false;

            if (string.IsNullOrEmpty(request.Email) || request.Email.Length > 100 || request.Email.Contains(";"))
                return false;

            if (string.IsNullOrEmpty(request.Street) || request.Street.Length > 200)
                return false;

            if (string.IsNullOrEmpty(request.City) || request.City.Length > 50)
                return false;

            if (string.IsNullOrEmpty(request.State) || request.State.Length > 2)
                return false;
            
            return true;
        }
    }
}