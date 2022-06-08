using System.ComponentModel.DataAnnotations;

namespace carsaApi.Models{


    public class Sitting{


         [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string value { get; set; }
    }
}