using System;
using System.Collections.Generic;
using System.Linq;
using carsaApi.Models;

namespace carsaApi.Data
{


    public class SlidersRepo
    {

        private readonly CarsaApiContext _context;

        public SlidersRepo(CarsaApiContext context)
        {
            _context = context;
        }









        public IEnumerable<Slider> GetAll()
        {
            return _context.Sliders.ToList();
        }

        public void AddSlider(Slider ct)
        {
            if (ct == null)
            {
                throw new ArgumentNullException(nameof(ct));
            }

            _context.Sliders.Add(ct);
        }


        public Slider GetSliderById(int id)
        {
            return _context.Sliders.FirstOrDefault(p => p.Id == id);
        }

        public void DeleteSlider(Slider ct)
        {
            if (ct == null)
            {
                throw new ArgumentNullException(nameof(ct));
            }

            _context.Sliders.Remove(ct);
        }



        public void UpdateSlider(Slider cmd)
        {

        }



        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }


    }
}