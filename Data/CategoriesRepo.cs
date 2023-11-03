using System;
using System.Collections.Generic;
using System.Linq;
using carsaApi.Models;

namespace carsaApi.Data
{


    public class CategoriesRepo
    {

        private readonly CarsaApiContext _context;

        public CategoriesRepo(CarsaApiContext context)
        {
            _context = context;
        }









        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public void AddCategory(Category ct)
        {
            if (ct == null)
            {
                throw new ArgumentNullException(nameof(ct));
            }

            _context.Categories.Add(ct);
        }


           public void AddCategoryWork(WorkshopCategory ct)
        {
            if (ct == null)
            {
                throw new ArgumentNullException(nameof(ct));
            }

            _context.WorkCategories.Add(ct);
        }



        public Category GetCategoryById(int id)
        {
            return _context.Categories.FirstOrDefault(p => p.Id == id);
        }

        public void DeleteCategory(Category ct)
        {
            if (ct == null)
            {
                throw new ArgumentNullException(nameof(ct));
            }

            _context.Categories.Remove(ct);
        }



        public void UpdateCategory(Category cmd)
        {

        }



        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }


    }
}