using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace carsaApi.Models
{
    public class Rate
    {
        public int Id { get; set; }

        public int WorkshopId { get; set; }


        public string UserId { get; set; }


       public string Comment { get; set; }

       public int Stare { get; set; }
        
       public DateTime CreateAte { get; set; }

        public   Rate()
        {  

             CreateAte = DateTime.Now;
        }
    }
}