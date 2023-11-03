using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using carsaApi.Data;
using carsaApi.Dto;
using carsaApi.Helpers;
using carsaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace carsaApi.Controllers
{
    [Route("workshops")]
    public class Workshops : Controller
    {


        private readonly CarsaApiContext _context;
        private IMapper _mapper;

        public Workshops(CarsaApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        [HttpPost]
        [Route("add-workshop")]
        public async Task<ActionResult> AddWorkshops([FromForm] Workshop item)
        {

            await _context.Workshops.AddAsync(item);
            _context.SaveChanges();
            return Ok(item);


        }


        [HttpGet]
        [Route("get-workshops")]
        public async Task<ActionResult> GetAll()
        {
            var workshopsItems = await _context.Workshops.ToListAsync();

            return Ok(workshopsItems);
        }


        // page
        [HttpGet]
        [Route("get-workshops-page")]
        public async Task<ActionResult> GetWorkshopsPage(
       [FromQuery] PagingParameterModel @params)
        {
            List<Workshop> workshops = new List<Workshop>();
            List<WorkshopCategory> categories = await _context.WorkCategories.ToListAsync();

            if (categories.Count > 0)
            {
                workshops = await _context.Workshops.Where(x => x.CategoryId == categories.First().Id).ToListAsync();

            }
            else
            {
                workshops = await _context.Workshops.ToListAsync();
            }

            var paginationMetadata = new PaginationMetadata(workshops.Count(), @params.Page, @params.ItemsPerPage);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            var items = workshops.Skip((@params.Page - 1) * @params.ItemsPerPage)
                                       .Take(@params.ItemsPerPage);
            return Ok(new
            {
                categories = categories,
                items = items,
                currentPage = @params.Page,
                totalPage = paginationMetadata.TotalPages
            });


        }


        [HttpPost]
        [Route("get-workshops-by-address")]
        public async Task<ActionResult> GetAllByAddress([FromForm] double latUser, [FromForm] double lngUser, [FromForm] int categoryId)
        {
            List<Workshop> workshops = new List<Workshop>();
            List<Workshop> workshopsItems = await _context.Workshops.Where(t => t.CategoryId == categoryId&&t.Status==1).ToListAsync();
            foreach (Workshop item in workshopsItems)
            {
                double distance = Functions.GetDistance(latUser, item.Lng, item.Lat, lngUser);

                if (distance < 65)
                {

                    workshops.Add(item);
                }


            }

            return Ok(workshops);
        }



        [HttpGet]
        [Route("get-workshop-by-id")]
        public async Task<ActionResult> GetWorkshopByID([FromForm] int id)
        {
            List<RateResponse> rateResponses = new List<RateResponse>();
            Workshop workshop = await _context.Workshops.FirstOrDefaultAsync(x => x.Id == id);

            if (workshop == null)
            {
                return NotFound();
            }
            //rates


            var rates = await _context.Rets.Where(t => t.WorkshopId == workshop.Id).ToListAsync();
            foreach (var item in rates)
            {
                User user = await _context.Users.FirstOrDefaultAsync(t => t.Id == item.UserId);

                RateResponse rateResponse = new RateResponse
                {
                    Rate = item,
                    UserName = user.FullName,
                    UserImage = user.ImageUrl
                };
                rateResponses.Add(
                    rateResponse
                );
            }



            return Ok(new
            {
                workshop = workshop,
                rates = rateResponses
            });
        }


        [HttpGet]
        [Route("get-workshop-by-CatId")]
        public async Task<ActionResult> GetWorkshopByCatID([FromForm] int categoryId,
        [FromForm] PagingParameterModel @params, [FromForm] double latUser, [FromForm] double lngUser)
        {
            List<Workshop> workshops = new List<Workshop>();

            //    var data=  workshops= await _context.Workshops.ToListAsync();

            var data = await _context.Workshops.Where(x => x.CategoryId == categoryId&&x.Status==1).ToListAsync();

            foreach (Workshop item in data)
            {
                double distance = Functions.GetDistance(latUser, item.Lng, item.Lat, lngUser);

                if (distance < 65)
                {

                    workshops.Add(item);
                }


            }




            var paginationMetadata = new PaginationMetadata(workshops.Count(), @params.Page, @params.ItemsPerPage);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            var items = workshops.Skip((@params.Page - 1) * @params.ItemsPerPage)
                                       .Take(@params.ItemsPerPage);
            return Ok(new
            {

                items = items,
                currentPage = @params.Page,
                totalPage = paginationMetadata.TotalPages
            });



        }



        [HttpGet]
        [Route("get-workshop-by-CatI-admin")]
        public async Task<ActionResult> GetWorkshopByCatIDAdmin([FromQuery] int categoryId)
        {


            //    var data=  workshops= await _context.Workshops.ToListAsync();

            var data = await _context.Workshops.Where(x => x.CategoryId == categoryId).ToListAsync();

            return Ok(data);


        }



        [HttpGet]
        [Route("get-workshop-by-userId")]
        public async Task<ActionResult> GetWorkshopByUserId([FromForm] string userId)
        {


            List<Post> posts = new List<Post>();
            Workshop workshop = await _context.Workshops.FirstOrDefaultAsync(t => t.UserId == userId);

            if (workshop == null)
            {
                return NotFound();
            }
            List<Comment> offers = await _context.Comments.Where(t => t.WorkshopId == workshop.Id).ToListAsync();
            List<Post> allPosts = await _context.Posts.Where(t => t.AcceptedOfferId == 0).ToListAsync();

            foreach (Post item in allPosts)
            {
                double distance = Functions.GetDistance(workshop.Lat, item.Lng, item.Lat, workshop.Lng);

                if (distance < 65)
                {

                    posts.Add(item);
                }


            }


            WorkshopDetails workshopDetails = new WorkshopDetails
            {
                workshop = workshop,
                offers = offers,
                posts = posts
            };

            return Ok(workshopDetails);

        }




        [HttpPost]
        [Route("delete-workshop")]
        public ActionResult DeleteWorkshop([FromForm] int id)
        {

            var workshop = _context.Workshops.FirstOrDefault(p => p.Id == id);
            if (workshop == null)
            {
                return NotFound();
            }

            _context.Remove(workshop);
            _context.SaveChanges();
            return Ok(workshop);



        }

        [HttpPut]
        [Route("update-workshop")]
        public async Task<ActionResult> UpdateWorkshop([FromForm] UpdateWorkshopDto UpdateProduct, [FromForm] int id)

        {
            Workshop workshop = await _context.Workshops.FirstOrDefaultAsync(p => p.Id == id);
            if (workshop == null)
            {
                return NotFound();
            }
            _mapper.Map(UpdateProduct, workshop);


            await _context.SaveChangesAsync();

            return Ok(workshop);
        }



           [HttpPost]
        [Route("update-workshop-status")]
        public async Task<ActionResult> UpdateWorkshopStatus([FromForm] int status, [FromForm] int id)

        {
            Workshop workshop = await _context.Workshops.FirstOrDefaultAsync(p => p.Id == id);
            if (workshop == null)
            {
                return NotFound();
            }
              workshop.Status=status;


            await _context.SaveChangesAsync();

            return Ok(workshop);
        }

    }
}