// Products
// id sellerId name detail price(double) image categoryId(int) brandId(int) status(int)

using System;
using System.ComponentModel.DataAnnotations;

namespace carsaApi.Models
{

    // id  userId price(double) status(int) sellerId createdAt(datetime)

    public class Order
    {

        [Key]
        public int Id { get; set; }
        public string userId { get; set; }

        public double Price { get; set; }

        public int AddressId { get; set; }


        public int Status { get; set; }

        public string SellerId { get; set; }




        public DateTime CreatedAt { get; set; }
        public Order()
        {
            CreatedAt = DateTime.Now.AddHours(1);


        }
    }
}