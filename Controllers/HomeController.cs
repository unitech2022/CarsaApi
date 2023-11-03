using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using carsaApi.Data;
using carsaApi.Helpers;
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

        [HttpGet("home")]
        public async Task<ActionResult> GetDashboard([FromQuery] string userId)
        {


            User user = await _context.Users.FirstOrDefaultAsync(t => t.Id==userId);
            var allProducts =await _context.Products.ToListAsync();

            List<Product> products=allProducts.Take(10).ToList();
            var allSliders =await _context.Products.Where(p =>p.OfferId==1).ToListAsync();
            var allCategories =await _context.Categories.ToListAsync();
            var allBrands =await _context.Brands.ToListAsync();
            var cateWorkshop =await _context.WorkCategories.ToListAsync();
            var Workshops =await _context.Workshops.Where(t => t.CategoryId ==1).ToListAsync();
            var sittings =await _context.Sittings.ToListAsync();
            var favorites = await _context.Favorites.Where(x => x.UserId == userId).ToListAsync();
        var carts = await _context.Carts.Where(x => (x.UserId == userId && x.OrderId == 0)).ToListAsync();


            Home response = new Home
            {
                brands = allBrands,
                products = products,
                categories = allCategories,
                 sliders = allSliders
                ,
                workshops =Workshops  ,
                categoriesWork = cateWorkshop, 
                 sittings=sittings,
                 favorites=favorites,
                 carts=carts,
                 User =user
               

            };
            return Ok(response);
        }


           [HttpGet("dashboard-home-admin")]
        public async Task<ActionResult> GetDashboardAdmin([FromForm] double latUser , [FromForm] double lngUser)
        {

            // List<Order> orders = new List<Order>();
            List<ResponseCart> responseCarts = new List<ResponseCart>();
            List<Workshop> workshops = new List<Workshop>();
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
                  
                  foreach (var cart in carts)
                  {
                    Product product=await _context.Products.FirstOrDefaultAsync(x => x.Id==cart.ProductId);

                    responseCarts.Add(new ResponseCart{
                        productModel=product,
                        cartModel=cart
                    });

                  }
                  

                  

                responseOrders.Add(new ResponseOrder
                {
                    Order = item,
                    UserEmail = user.Email,
                    UserName = user.FullName,
                    UserPhone = user.UserName,
                    Address = address,
                    // Products=responseCarts,
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
                  
                  foreach (var cart in carts)
                  {
                    Product product=await _context.Products.FirstOrDefaultAsync(x => x.Id==cart.ProductId);

                    responseCarts.Add(new ResponseCart{
                        productModel=product,
                        cartModel=cart
                    });

                  }
                  

                  

                responseOrders.Add(new ResponseOrder
                {
                    Order = item,
                    UserEmail = user.Email,
                    UserName = user.FullName,
                    UserPhone = user.UserName,
                    Address = address,
                    // Products=responseCarts,
                });

            }
            }
     //get work shops

           List<Workshop> workshopsItems = await _context.Workshops.ToListAsync();
            foreach (Workshop item in workshopsItems)
            {
                double distance = Functions.GetDistance(latUser, item.Lat, lngUser, item.Lng);
                if (distance < 30)
                {

                    workshops.Add(item);
                }


            }



            var response = new
            {
                countProduct = countProduct,
                countCategories = countCategories,
                countOrders = countOrders,
                countUsers = countUsers,
                orders = responseOrders,
                workshops =workshops
            };
            return Ok(response);
        }


    }
}
