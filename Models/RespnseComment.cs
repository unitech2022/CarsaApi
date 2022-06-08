





using System;
using System.ComponentModel.DataAnnotations;

namespace carsaApi.Models
{

    // comments 
    // id text sellerId postId(int) createdAt(datetime)

    public class ResponseComment
    {

        [Key]
        public int Id { get; set; }


        public string Text { get; set; }

         public string UserId { get; set; }

        public string SellerId { get; set; }
        public int PostId { get; set; }


        public DateTime CreatedAt { get; set; }

        public string UserName { get; set; }
        public string Phone { get; set; }

        public string ImageUrl { get; set; }
    
        
    }
}