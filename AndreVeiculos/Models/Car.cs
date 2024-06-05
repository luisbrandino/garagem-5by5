namespace Models
{
    [Table("tb_car")]
    public class Car : Model
    {
        [PrimaryKey]
        public string LicensePlate { get; set; }
        public string Name { get; set; }
        public int ModelYear { get; set; }
        public int ManufactureYear { get; set; }
        public bool Sold { get; set; }
    }
}
