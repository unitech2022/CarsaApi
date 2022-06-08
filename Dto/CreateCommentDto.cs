





using System;
using System.ComponentModel.DataAnnotations;

namespace carsaApi.Dto
{

    // comments 
    // id text sellerId postId(int) createdAt(datetime)

    public class CreateCommentDto
    {




        public string Text { get; set; }

        public int SellerId { get; set; }
        public int PostId { get; set; }


        public string UserId { get; set; }





    }
}