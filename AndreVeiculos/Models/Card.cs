namespace Models
{
    [Table("tb_card")]
    public class Card : Model
    {
        [PrimaryKey]
        public string Number { get; set; }
        public string Name { get; set; }
        public string VerificationCode { get; set; }
        public DateOnly ExpirationDate { get; set; }
    }
}
