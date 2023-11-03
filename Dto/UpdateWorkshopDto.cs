using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace carsaApi.Dto
{
    public class UpdateWorkshopDto
    {
        
        public string Name { get; set; }
        public string Desc { get; set; }


        public string Image { get; set; }

        public string Address { get; set; }


        public double Lat { get; set; }


        public double Lng { get; set; }


        public int Status { get; set; }
    }
}