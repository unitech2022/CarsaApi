using System.ComponentModel.DataAnnotations;

namespace carsaApi.Models
{

    public class CartResponse
    {

        
        public Cart CartItem { get; set; }

        public Product Product { get; set; }


    }
}