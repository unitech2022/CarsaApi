using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace carsaApi.Models
{
    public class ResponseMessage
    {
        public UserDetailResponse Sender { get; set; }
        public Support Support { get; set; }

    }
}