





using System;
using System.ComponentModel.DataAnnotations;

namespace carsaApi.Models
{

    // comments 
    // id text sellerId postId(int) createdAt(datetime)

    public class Comment
    {

        [Key]
        public int Id { get; set; }


          public string Text { get; set; }

          public string UserId { get; set; }
 
          public string Phone { get; set; }

          public int WorkshopId { get; set; }
          public int PostId { get; set; }

          public int Accepted { get; set; }

          public DateTime CreatedAt { get; set; }
       public Comment()
        {
            CreatedAt = DateTime.Now;
            Accepted =0;

        }
        
    }
}