using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace carsaApi.Models
{
    public class RateResponse
    {
        public Rate Rate { get; set; }

        public string UserName { get; set; }

        public  string  UserImage { get; set; }
    }
}