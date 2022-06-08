using System;
using System.Collections.Generic;
using System.Linq;
using carsaApi.Models;

namespace carsaApi.Data
{


    public class FavRepo
    {

        private readonly CarsaApiContext _context;

        public FavRepo(CarsaApiContext context)
        {
            _context = context;
        }









        public IEnumerable<Favorite> GetAll()
        {
            return _context.Favorites.ToList();
        }

        public void AddFavorite(Favorite ct)
        {
            if (ct == null)
            {
                throw new ArgumentNullException(nameof(ct));
            }
            

            _context.Favorites.Add(ct);
        }


        public Favorite GetFavoritesById(int id)
        {
            return _context.Favorites.FirstOrDefault(p => p.Id == id);
        }

        public void DeleteFavorites(Favorite brand)
        {
            if (brand == null)
            {
                throw new ArgumentNullException(nameof(brand));
            }

            _context.Favorites.Remove(brand);
        }



        public void UpdateFavorites(Favorite cmd)
        {

        }



        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }


    }
}