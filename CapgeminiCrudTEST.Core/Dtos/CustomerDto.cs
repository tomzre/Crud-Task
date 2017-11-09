using System.ComponentModel.DataAnnotations;

namespace CrudTT.Core.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        public AddressDto Address { get; set; }
    }
}
