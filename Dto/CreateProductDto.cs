// Products
// id sellerId name detail price(double) image categoryId(int) brandId(int) status(int)

using System.ComponentModel.DataAnnotations;

namespace carsaApi.Dto
{

    public class CreateProductDto
    {

      
        public string SellerId { get; set; }

 public int CarModelId { get; set; }

        public string Name { get; set; }


        public string Detail { get; set; }

        public double Price { get; set; }
   
          
        public string Image { get; set; }

       public bool DetailsPrice { get; set; }

        public string TimeDelivery { get; set; }
         
        public int CategoryId { get; set; }

        
          public int OfferId { get; set; }

        public int BrandId { get; set; }

        public int Status { get; set; }
    }
}