namespace CapgeminiCrudTEST.Core.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public AddressDto Address { get; set; }
    }
}
