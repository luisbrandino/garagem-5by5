namespace Models
{
    public class CarService : Model
    {
        public string CarLicensePlate { get; set; } 
        public int ServiceId { get; set; }
        public bool Status { get; set; }
    }
}
