using System;
using System.Collections.Generic;
using System.Linq;
using carsaApi.Models;

namespace carsaApi.Data
{


    public class BrandsRepo
    {

        private readonly CarsaApiContext _context;

        public BrandsRepo(CarsaApiContext context)
        {
            _context = context;
        }









        public IEnumerable<Brand> GetAll()
        {
            return _context.Brands.ToList();
        }

        public void CreateBrand(Brand ct)
        {
            if (ct == null)
            {
                throw new ArgumentNullException(nameof(ct));
            }

            _context.Brands.Add(ct);
        }


        public Brand GetBrandById(int id)
        {
            return _context.Brands.FirstOrDefault(p => p.Id == id);
        }

        public void DeleteBrand(Brand brand)
        {
            if (brand == null)
            {
                throw new ArgumentNullException(nameof(brand));
            }

            _context.Brands.Remove(brand);
        }



        public void UpdateBrand(Brand cmd)
        {

        }



        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }


    }
}