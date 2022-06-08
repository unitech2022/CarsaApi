using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using carsaApi.Data;
using carsaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace carsaApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly CarsaApiContext _context;

        public HomeController(CarsaApiContext context)
        {
            this._context = context;
        }

        [HttpGet("dashboard-home")]
        public async Task<ActionResult> GetDashboard()
        {


            
            var allProducts =await _context.Products.ToListAsync();
            var allSliders =await _context.Products.Where(p =>p.OfferId==1).ToListAsync();
            var allCategories =await _context.Categories.ToListAsync();
            var allBrands =await _context.Brands.ToListAsync();
            var allNeeds =await _context.Needs.ToListAsync();
            var sittings =await _context.Sittings.ToListAsync();




            Home response = new Home
            {
                brands = allBrands,
                products = allProducts,
                categories = allCategories,
                sliders = allSliders
                ,
                needs = allNeeds,
                 sittings=sittings
               

            };
            return Ok(response);
        }


           [HttpGet("dashboard-home-admin")]
        public async Task<ActionResult> GetDashboardAdmin()
        {

            // List<Order> orders = new List<Order>();
            List<ResponseOrder> responseOrders = new List<ResponseOrder>();
            int countProduct = _context.Products.Count();
            int countCategories = _context.Categories.Count();
            int countOrders = _context.Orders.Count();
            int countUsers = _context.Users.Count();






            if (countOrders > 10)
            {
                //   var  orders =  _context.Orders.TakeLast(10).ToList();

                var data = await _context.Orders.ToListAsync();
                var newData=data.TakeLast(10).ToList();
                // List<Cart> carts=new List<Cart>(); 
                  foreach (var item in newData)
            {
                User user = await _context.Users.FindAsync(item.userId);
                Address address = _context.Addresses.FirstOrDefault(p => p.Id == item.AddressId);
                  
  
  
  
               var carts=_context.Carts.Where(p => p.OrderId == item.Id).ToList();
                  

                responseOrders.Add(new ResponseOrder
                {
                    Order = item,
                    UserEmail = user.Email,
                    UserName = user.FullName,
                    UserPhone = user.UserName,
                    Address = address,
                    Products=carts,
                });

            }
                

            }
            else
            {
                var data = await _context.Orders.ToListAsync();
                foreach (var item in data)
            {
                User user = await _context.Users.FindAsync(item.userId);
                Address address = _context.Addresses.FirstOrDefault(p => p.Id == item.AddressId);
                  
  
  
  
               var carts=_context.Carts.Where(p => p.OrderId == item.Id).ToList();
                  

                responseOrders.Add(new ResponseOrder
                {
                    Order = item,
                    UserEmail = user.Email,
                    UserName = user.FullName,
                    UserPhone = user.UserName,
                    Address = address,
                    Products=carts,
                });

            }
            }




            var response = new
            {
                countProduct = countProduct,
                countCategories = countCategories,
                countOrders = countOrders,
                countUsers = countUsers,
                orders = responseOrders
            };
            return Ok(response);
        }


    }
}
