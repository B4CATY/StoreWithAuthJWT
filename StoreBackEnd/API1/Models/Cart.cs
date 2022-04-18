using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API1.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public ICollection<VideoCart> VideoCarts { get; set; } = new List<VideoCart>();
        //public CartVideoCart CartVideoCart { get; set; }
    }
}
