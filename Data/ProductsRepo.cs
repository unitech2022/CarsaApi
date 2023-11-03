using System;
using System.Collections.Generic;
using System.Linq;
using carsaApi.Models;

namespace carsaApi.Data
{


    public class ProductsRepo
    {

        private readonly CarsaApiContext _context;

        public ProductsRepo(CarsaApiContext context)
        {
            _context = context;
        }









        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public void AddProduct(Product ct)
        {
            if (ct == null)
            {
                throw new ArgumentNullException(nameof(ct));
            }

            _context.Products.Add(ct);
        }


        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public void DeleteProduct(Product brand)
        {
            if (brand == null)
            {
                throw new ArgumentNullException(nameof(brand));
            }

            _context.Products.Remove(brand);
        }



        public void UpdateProduct(Product cmd)
        {

        }



        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }


    }
}