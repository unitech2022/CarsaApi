namespace carsaApi.Models
{


    public class ResponseFav
    {



        public bool status { get; set; }
        public string Message { get; set; }

        public Favorite Favorite { get; set; }
    }
}