





using System;
using System.ComponentModel.DataAnnotations;

namespace carsaApi.Models
{

    // comments 
    // id text sellerId postId(int) createdAt(datetime)

    public class ResponseComment
    {

        public Comment comment  { get; set; }

        public string NameWorkShop { get; set; }
       

        public string ImageUrlWorkShop { get; set; }
    
        
    }
}