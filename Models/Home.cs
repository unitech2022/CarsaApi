using System.Collections.Generic;

namespace carsaApi.Models{


    public class Home{

        public List<Brand> brands { get; set; }

        public List<Product> sliders { get; set; }

        public List<Product> products { get; set; }

        public List<Category> categories { get; set; }


        public List<WorkshopCategory> categoriesWork { get; set; }


         public List<Workshop> workshops { get; set; }
        // public List<Need> needs { get; set; }

        public List<Sitting> sittings { get; set; }

        public List<Favorite> favorites { get; set; }
         public List<Cart> carts { get; set; }

        public User User { get; set; }

    }

}