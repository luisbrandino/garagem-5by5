using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Car : Model
    {
        [JsonPropertyAttribute("licensePlate")]
        public string LicensePlate { get; set; }

        [JsonPropertyAttribute("name")]
        public string Name { get; set; }

        [JsonPropertyAttribute("modelYear")]
        public string ModelYear { get; set; }

        [JsonPropertyAttribute("manufactureYear")]
        public string ManufactureYear { get; set; }

        [JsonPropertyAttribute("color")]
        public string Color { get; set; }
    }
}
