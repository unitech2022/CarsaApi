

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

         public int AcceptedOfferId { get; set; }

        public string UserId { get; set; }

        public int Status { get; set; }

        public double Lat { get; set; }

        public double Lng { get; set; }

        public string Images { get; set; }



        public string Phone { get; set; }


         public string ModelCar { get; set; }

         public string ColorCar { get; set; }

          public string NameCar { get; set; }


        public string Desc { get; set; }


        public DateTime CreatedAt { get; set; }

        public Post()
        {
            CreatedAt = DateTime.Now;
            AcceptedOfferId =0;
            Status =0 ;


        }
    }
}