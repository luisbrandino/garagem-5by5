namespace Models
{
    [Table("tb_purchase")]
    public class Purchase : Model
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        [Column("car_license_plate")]
        public Car Car { get; set; }
        public decimal Price { get; set; }
        public DateTime PurchasedAt { get; set; }
    }
}
