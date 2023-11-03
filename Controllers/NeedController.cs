using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using carsaApi.Data;
using carsaApi.Models;using carsaApi.Dto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace carsaApi.Controllers
{

    [Route("need")]
    [ApiController]
    public class NeedsController : ControllerBase
    {


        private readonly CarsaApiContext _context;


        private IMapper _mapper;
        public NeedsController(IMapper mapper, CarsaApiContext context)
        {

            _mapper = mapper;
            _context = context;

        }



        [HttpGet]
        [Route("get-Needs")]
        public async Task<ActionResult> GetAll()
        {
            var data = await _context.Needs.ToListAsync();
            // var bransItems = _repository.GetAll();
            return Ok(data);
        }



        [HttpPost]
        [Route("add-need")]
        public async Task<ActionResult> AddNeed([FromForm] CreateNeedDto Need)
        {


            if (Need == null)
            {
                throw new ArgumentNullException(nameof(Need));
            }
            var coomansModel = _mapper.Map<Need>(Need);
            await _context.Needs.AddAsync(coomansModel);


            _context.SaveChanges();
            // var commandReadDto = _mapper.Map<CategoryReadDto>(coomansModel);


            return Ok(coomansModel);


        }



        [HttpPost]
        [Route("delete-Need")]
        public async Task<ActionResult> DeleteNeed([FromForm] int id)
        {


            Need address = await _context.Needs.FindAsync(id);

            if (address == null)
            {
                return NotFound();
            }
            _context.Needs.Remove(address);
            _context.SaveChanges();
            return Ok(address);

        }




        // [HttpPost("{id}")]
        // [Route("update-Need")]
        // public ActionResult UpdateCategory([FromForm] int id, [FromForm] CreateNeedDto Need)
        // {
        //     var NeedModelFromRepo = _repository.GetNeedById(id);
        //     if (NeedModelFromRepo == null)
        //     {
        //         return NotFound();
        //     }


        //     _mapper.Map(Need, NeedModelFromRepo);

        //     _repository.UpdateNeed(NeedModelFromRepo);

        //     _repository.SaveChanges();

        //     return NoContent();

        // }

    }
}