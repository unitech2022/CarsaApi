﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace carsaApi.Models
{
    public class UserDetailResponse
    {


        public string Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
        public string Status { get; set; }
        public string Role { get; set; }

         public DateTime CreatedAt { get; set; }

    }
}
