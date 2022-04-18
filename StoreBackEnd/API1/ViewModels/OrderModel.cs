using API1.Models;
using System.Collections.Generic;

namespace API1.ViewModels
{
    public class OrderModel
    {
        public int OrderId { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
