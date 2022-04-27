using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API1.Models
{
    public class VideoCart
    {
        public int Id { get; set; }
        public int? Categoryid { get; set; }
        [Required]
        public string NameProduct { get; set; }
        [Required]
        public int Price { get; set; }
        public string? Img { get; set; }
        [JsonIgnore]
        public virtual Category? Category { get; set; }
        [JsonIgnore]
        public ICollection<Orders> Orders { get; set; }
        
    }
}
