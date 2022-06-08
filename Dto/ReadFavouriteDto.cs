using System.ComponentModel.DataAnnotations;

namespace carsaApi.Dto
{

    public class ReadFavoriteDto
    {

        [Key]
        public int Id { get; set; }

        public string ProductId { get; set; }
        public string SellerId { get; set; }

        public string Name { get; set; }


        public string Detail { get; set; }

        public bool IsCart { get; set; }

        public bool IsFav { get; set; }


        public double Price { get; set; }

        public string Image { get; set; }

        public int CategoryId { get; set; }


        public int BrandId { get; set; }

        public int Status { get; set; }

        ReadFavoriteDto()
        {

            IsCart = false;
            IsFav = true;
        }
    }


}