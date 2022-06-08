

using System;
using System.ComponentModel.DataAnnotations;

namespace carsaApi.Models
{

    // Posts
    // id images description userId createdAt(datetime)

    public class Post
    {

        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }

        public int Status { get; set; }



        public string Images { get; set; }


        public string Phone { get; set; }


        public string Desc { get; set; }


        public DateTime CreatedAt { get; set; }

        public Post()
        {
            CreatedAt = DateTime.Now;


        }
    }
}