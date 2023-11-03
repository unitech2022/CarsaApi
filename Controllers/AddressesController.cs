using carsaApi.Data;
using carsaApi.Helpers;
using carsaApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace carsaApi.Controllers
{
    public class AddressesController : Controller
    {
        //  dotnet commends

// dotnet publish --configuration Release
// migrations dotnet
// dotnet ef migrations add InitialCreate
 // update database 
// dotnet ef database update
// create
// dotnet new webapi -n name 

        private readonly CarsaApiContext myDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public AddressesController(CarsaApiContext context, IHttpContextAccessor httpContextAccessor
                     )
        {
            this.myDbContext = context;
            this._httpContextAccessor = httpContextAccessor;

        }

        [Authorize(Roles ="user")]
        [HttpGet("address/get-addresses")]
        public async Task<ActionResult> getAdresses()
        {
            User user = await Functions.getCurrentUser(_httpContextAccessor, myDbContext);
            var data = await myDbContext.Addresses.Where(x => x.UserId == user.Id && x.Status==0).AsNoTracking().ToListAsync();
            return Ok(data);
        }


        [Authorize(Roles = "user")]
        [HttpPost("address/add")]
        public async Task<ActionResult> addAdress(Address address)
        {
            User user = await Functions.getCurrentUser(_httpContextAccessor, myDbContext);
            address.UserId = user.Id;
            await myDbContext.Addresses.AddAsync(address);
            myDbContext.SaveChanges();
            return Ok(address);
        }

        [Authorize(Roles = "user")]
        [HttpPost("address/update")]
        public async Task<ActionResult> updateAdress(Address add)
        {
            Address address = await myDbContext.Addresses.FindAsync(add.Id);
            if (add.Lable!=null) {
                address.Lable = add.Lable;
            }
            if (add.Lat != 0.0)
            {
                address.Lat = add.Lat;
            }
            if (add.Lng != 0.0)
            {
                address.Lng = add.Lng;
            }
       

            await myDbContext.SaveChangesAsync();
            return Ok(address);
        }



        [Authorize(Roles = "user")]
        [HttpPost("address/delete")]
        public async Task<ActionResult> deleteAddress(int id)
        {
            Address address = await myDbContext.Addresses.FindAsync(id);
             address.Status =1;
            myDbContext.SaveChanges();
            return Ok(address);
        }

    }
}
