﻿namespace Models
{
    public abstract class Person : Model
    {
        /**
         * It's necessary to store the ID template
         */
        [PrimaryKey]
        public string IdentificationNumber { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }

        [Column("address_id")]
        public Address Address { get; set; }
    }
}
