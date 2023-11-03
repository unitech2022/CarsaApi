using System.ComponentModel.DataAnnotations;
using carsaApi.Models;
namespace carsaApi.Dto
{

    public class ResponseFavorite
    {

      public Favorite Favorite { get; set; }
      public Product Product { get; set; }

       
    }


}