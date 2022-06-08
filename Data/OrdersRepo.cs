using System;
using System.Collections.Generic;
using System.Linq;
using carsaApi.Models;

namespace carsaApi.Data
{


    public class OrdersRepo
    {

        private readonly CarsaApiContext _context;

        public OrdersRepo(CarsaApiContext context)
        {
            _context = context;
        }









        public IEnumerable<Order> GetAll()
        {
            return _context.Orders.ToList();
        }

        public void AddOrder(Order ct)
        {
            if (ct == null)
            {
                throw new ArgumentNullException(nameof(ct));
            }

            _context.Orders.Add(ct);
        }


        public Order GetOrderById(int id)
        {
            return _context.Orders.FirstOrDefault(p => p.Id == id);
        }

        public void DeleteOrder(Order Order)
        {
            if (Order == null)
            {
                throw new ArgumentNullException(nameof(Order));
            }

            _context.Orders.Remove(Order);
        }



        public void UpdateOrder(Order cmd)
        {

        }



        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }


    }
}