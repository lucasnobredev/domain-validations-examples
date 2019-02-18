using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainValidationExamples.DTOs
{
    public class OrderViewModel
    {
        public IList<OrderItemDTO> Items { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}
