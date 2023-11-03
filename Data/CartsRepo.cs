using System;
using System.Collections.Generic;
using System.Linq;
using carsaApi.Models;

namespace carsaApi.Data
{


    public class CartsRepo
    {

        private readonly CarsaApiContext _context;

        public CartsRepo(CarsaApiContext context)
        {
            _context = context;
        }









        public IEnumerable<Cart> GetAll()
        {
            return _context.Carts.ToList();
        }

        public void AddCart(Cart ct)
        {
            if (ct == null)
            {
                throw new ArgumentNullException(nameof(ct));
            }
            

            _context.Carts.Add(ct);
        }


        public Cart GetCartById(int id)
        {
            return _context.Carts.FirstOrDefault(p => p.Id == id);
        }

        public void DeleteCart(Cart brand)
        {
            if (brand == null)
            {
                throw new ArgumentNullException(nameof(brand));
            }

            _context.Carts.Remove(brand);
        }



        public void UpdateCart(Cart cmd)
        {

        }



        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }


    }
}