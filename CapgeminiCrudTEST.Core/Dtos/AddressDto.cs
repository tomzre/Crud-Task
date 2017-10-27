using System.ComponentModel.DataAnnotations;

namespace CapgeminiCrudTEST.Core.Dtos
{
    public class AddressDto
    {
        public int Id { get; set; }
        [Required]
        public int HouseNumber { get; set; }
        [Required]
        public string StreetName { get; set; }



    }
}
