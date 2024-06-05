﻿namespace Models
{
    [Table("tb_payment")]
    public class Payment : Model
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        [Column("card_number")]
        public Card? Card { get; set; }

        [Column("payment_slip_id")]
        public PaymentSlip? PaymentSlip { get; set; }

        [Column("pix_id")]
        public Pix? Pix { get; set; }

        public DateTime PaidAt { get; set; }
    }
}
