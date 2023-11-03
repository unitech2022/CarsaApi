

using System;
using System.ComponentModel.DataAnnotations;

namespace carsaApi.Dto
{

    // Posts
    // id images description userId createdAt(datetime)

    public class CreatePostDto
    {


        
         public int AcceptedOfferId { get; set; }

        public string UserId { get; set; }

        public int Status { get; set; }

        public string Images { get; set; }


        public string Phone { get; set; }


         public string ModelCar { get; set; }

         public string ColorCar { get; set; }

          public string NameCar { get; set; }


        public string Desc { get; set; }





    }
}