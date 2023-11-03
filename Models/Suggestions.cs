using System;
using System.ComponentModel.DataAnnotations;

namespace carsaApi.Models{


    public class Suggestions{


         [Key]
        public int Id { get; set; }

        public string UserEmail { get; set; }

        public string UserName { get; set; }


          public string UserId { get; set; }

         public string UserPhone{ get; set; }

          public string Message { get; set; }

        public DateTime CreatedAt { get; set; }
        public Suggestions() {
           CreatedAt = DateTime.Now;
        }
    }


    }
