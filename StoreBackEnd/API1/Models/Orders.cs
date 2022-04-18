using System.Text.Json.Serialization;

namespace API1.Models
{
    public class Orders
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int Quantity { get; set; }

        [JsonIgnore]
        public int OrderId { get; set; }
        [JsonIgnore]
        public int VideoCartId { get; set; }

        //[JsonIgnore]
        public VideoCart VideoCart { get; set; }
        [JsonIgnore]
        public Order Order { get; set; }
    }
}
