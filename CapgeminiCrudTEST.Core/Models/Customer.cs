﻿namespace CapgeminiCrudTEST.Core.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public int AddressId { get; set; }

        public Address Address { get; set; }
    }
}
