using System;
using System.ComponentModel.DataAnnotations;

namespace carsaApi.Dto{


    public class CreateSuggestions{


        

        public string UserEmail { get; set; }

        public string UserName { get; set; }


          public string UserId { get; set; }

         public string UserPhone{ get; set; }

          public string Message { get; set; }

        public DateTime CreatedAt { get; set; }

       


    }
}