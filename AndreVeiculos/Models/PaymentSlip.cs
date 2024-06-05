﻿namespace Models
{
    [Table("tb_payment_slip")]
    public class PaymentSlip : Model
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public int Number { get; set; }
        public DateTime DueDate { get; set; }
    }
}
