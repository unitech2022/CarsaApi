

using System;
using System.ComponentModel.DataAnnotations;

namespace carsaApi.Models
{

    // Posts
    // id images description userId createdAt(datetime)

    public class ResponsePost
    {

       public Post Post { get; set; }
       public string ImageUrlUser { get; set; }

       public string NameUser { get; set; }
    }
}