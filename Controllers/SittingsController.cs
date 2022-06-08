using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using carsaApi.Dto;
using carsaApi.Data;
using carsaApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace awamrakeApi.Controllers
{

    [Route("sitting")]
    [ApiController]
    public class SittingsController : ControllerBase
    {


        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CarsaApiContext _context;


        private IMapper _mapper;
        public SittingsController(IMapper mapper, CarsaApiContext context,IHttpContextAccessor httpContextAccessor)
        {


            _context = context;
            _mapper = mapper;
            _httpContextAccessor=httpContextAccessor;
            
        }



        [HttpGet]
        [Route("get-sittings")]
        public async Task<ActionResult> GetAll()
        {
            var bransItems = await _context.Sittings.ToListAsync();
            return Ok(bransItems);
        }



        [HttpPost]
        [Route("add-sitting")]
        public async Task<ActionResult> CreateSitting([FromForm] Sitting sitting)
        {
            await _context.Sittings.AddAsync(sitting);
            _context.SaveChanges();
            return Ok(sitting);


        }



        [HttpPost]
        [Route("delete-sitting")]
        public ActionResult DeleteCategory([FromForm] int id)
        {

            var favoriteModelFromRepo = _context.Sittings.FirstOrDefault(p =>p.Id==id);
            if (favoriteModelFromRepo == null)
            {
                return NotFound();
            }

            _context.Remove(favoriteModelFromRepo);
            _context.SaveChanges();
            return Ok(favoriteModelFromRepo);



        }




        [HttpPost()]
        [Route("update-sitting")]
        public ActionResult UpdateSitting([FromForm] int id, [FromForm] CreateSittingDto category)
        {
            var brandModelFromRepo =_context.Sittings.FirstOrDefault(p =>p.Id==id);
            if (brandModelFromRepo == null)
            {
                return NotFound();
            }


            _mapper.Map(category, brandModelFromRepo);

    
           _context.SaveChangesAsync();

            return NoContent();

        }

    }
}