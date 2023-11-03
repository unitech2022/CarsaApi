using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace carsaApi.Models
{
    public class WorkshopDetails
    {

        
        public Workshop workshop { get; set; }

        public List<Comment> offers { get; set; }

        public List<Post> posts { get; set; }
    }
}