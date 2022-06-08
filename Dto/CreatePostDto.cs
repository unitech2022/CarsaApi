

using System;
using System.ComponentModel.DataAnnotations;

namespace carsaApi.Dto
{

    // Posts
    // id images description userId createdAt(datetime)

    public class CreatePostDto
    {


        public string UserId { get; set; }

        public string Images { get; set; }

        public string Phone { get; set; }
        public string Desc { get; set; }





    }
}