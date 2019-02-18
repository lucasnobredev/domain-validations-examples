using DomainValidationExamples.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainValidationExamples.Domain
{
    public class Order
    {
        public static Order CreateOrder(OrderViewModel orderViewModel)
        {
            return new Order();
        }

        public static bool CanCreateOrder(OrderViewModel orderViewModel, out Order order)
        {
            order = new Order();

            return true;
        }

        public bool IsValid()
        {
            return false;
        }
    }
}
