using System.ComponentModel.DataAnnotations;

namespace MoviesApi.dtos
{
    public class createGeneraDto
    {
        [MaxLength(100)]
        public  string Name { get; set; }
    }
}
