using System.ComponentModel.DataAnnotations;

namespace carsaApi.Models
{

    public class Brand
    {

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }


    }
}