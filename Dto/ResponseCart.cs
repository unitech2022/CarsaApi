using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using carsaApi.Dto;
namespace carsaApi.Models
{
    public class ResponseCart
    {
        public Cart cartModel { get; set; }

        public Product productModel { get; set; }
    }
}