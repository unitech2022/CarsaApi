using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace carsaApi.Models
{
    public class Workshop
    {


        public int Id { get; set; }


        public int CategoryId { get; set; }

         public string UserId { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }

      
        public string Image { get; set; }

        public string Address { get; set; }


        public double Lat { get; set; }


        public double Rate { get; set; }
        public double Lng { get; set; }

        public string Phone { get; set; }

        public string PhoneWhats { get; set; }
        public int Status { get; set; }

        public Workshop()
        {

            Rate = 0.0;

            Status = 0;
        }
    }


}