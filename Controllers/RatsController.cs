using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using carsaApi.Data;
using carsaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace carsaApi.Controllers
{
    [Route("rate")]
    public class RatsController : Controller
    {

        private readonly CarsaApiContext _context;
        private IMapper _mapper;

        public RatsController(CarsaApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("add-rate")]
        public async Task<ActionResult> AddRateWorkshops([FromForm] Rate rate)
        {
           Rate checkRate=await _context.Rets.FirstOrDefaultAsync(t => t.UserId ==rate.UserId&&t.WorkshopId==rate.WorkshopId);
            Workshop workshop = await _context.Workshops.FirstOrDefaultAsync(t => t.Id == rate.WorkshopId);
           if(checkRate==null){

           await _context.Rets.AddAsync(rate);
            _context.SaveChanges();
            List<Rate> rates = await _context.Rets.Where(t => t.WorkshopId == rate.WorkshopId).ToListAsync();
           
            //culact rate WorkShop
            int rateConte = rates.Count();
            Console.WriteLine("rateConte"+rateConte);
            int stars = rates.Sum(t => t.Stare);
            Console.WriteLine("stars"+stars);
            double totalRate= stars / rateConte;
            Console.WriteLine("rate"+totalRate);
            workshop.Rate =totalRate; 
            _context.SaveChanges();
            return Ok(new{
                message ="تم التقييم بنجاح ",
                rate =rate
            });
           }else {
            List<Rate> rates = await _context.Rets.Where(t => t.WorkshopId == rate.WorkshopId).ToListAsync();
            checkRate.Stare =rate.Stare;
            int rateConte = rates.Count();
            Console.WriteLine("rateConte"+rateConte);
            int stars = rates.Sum(t => t.Stare);
            Console.WriteLine("stars"+stars);
            double totalRate= stars / rateConte;
            Console.WriteLine("rate"+totalRate);
            workshop.Rate =totalRate; 
            _context.SaveChanges();
          

            return Ok(new {
                message="تم تعديل التقييم ",
                rate =rate
            });
           }
             
           


        }

         [HttpGet]
        [Route("get-rates")]
        public async Task<ActionResult> GetAll([FromForm] int workShopId)
        {
            List<RateResponse> rateResponses=new List<RateResponse>();
            var rates = await _context.Rets.Where(t => t.WorkshopId==workShopId).ToListAsync();
             foreach (var item in rates)
             {
                User user=await _context.Users.FirstOrDefaultAsync(t => t.Id==item.UserId);

                RateResponse rateResponse=new RateResponse{
                        Rate=item,
                        UserName=user.FullName,
                        UserImage=user.ImageUrl
                    }; 
                rateResponses.Add(
                    rateResponse
                );
             }

            return Ok(rateResponses);
        }



        [HttpPut]
        [Route("update-rate")]
        public async Task<ActionResult> UpdateRate([FromForm] int star, [FromForm] int id,[FromForm] int workShopId)

        {
              Rate checkRate=await _context.Rets.FirstOrDefaultAsync(t => t.Id ==id);
          
            if (checkRate == null)
            {
                return NotFound();
            }
            checkRate.Stare = star;
             List<Rate> rates = await _context.Rets.Where(t => t.WorkshopId == workShopId).ToListAsync();
              Workshop workshop = await _context.Workshops.FirstOrDefaultAsync(t => t.Id == workShopId);
            int rateConte = rates.Count();
            Console.WriteLine("rateConte"+rateConte);
            int stars = rates.Sum(t => t.Stare);
            Console.WriteLine("stars"+stars);
            double totalRate= stars / rateConte;
            Console.WriteLine("rate"+totalRate);
            workshop.Rate =totalRate; 
            _context.SaveChanges();
          

            return Ok(new {
                message="تم تعديل التقييم ",
                rate =checkRate
            });

            
        }


    }





    
}