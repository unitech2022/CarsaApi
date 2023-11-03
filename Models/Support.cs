using System;
namespace carsaApi.Models
{
    public class Support
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string UserId { get; set; }
        public string Sender { get; set; }

        public DateTime Date { get; set; }

        public Support()
        {
            Date = DateTime.Now ;
        }
    }
}
