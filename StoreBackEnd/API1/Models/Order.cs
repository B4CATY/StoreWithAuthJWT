using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace API1.Models
{
    public class Order
    {
        [JsonIgnore]
        public int Id { get; set; }
        public DateTime PurchaseDate { get; set; } = DateTime.Now;
        [JsonIgnore]
        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public ICollection<Orders> Orders { get; set; }
    }
}
