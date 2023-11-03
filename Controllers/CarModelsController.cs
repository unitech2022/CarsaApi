using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using carsaApi.Data;
using carsaApi.Dto;
using carsaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace carsaApi.Controllers
{
    [Route("carModel")]
    public class CarModelsController : ControllerBase
    {
        private readonly CarsaApiContext _context;
        private IMapper _mapper;


        public CarModelsController(CarsaApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpPost]
        [Route("add-carModel")]
        public async Task<ActionResult> AddCarModel([FromForm] CarModel item)
        {


            await _context.CarModels.AddAsync(item);
            _context.SaveChanges();
            return Ok(item);

        }

       [HttpGet]
        [Route("get-carModels")]
        public async Task<ActionResult> GetAll()
        {
            var carModels = await _context.CarModels.ToListAsync();

            return Ok(carModels);
        }


        [HttpGet]
        [Route("get-carModels-by-carId")]
        public async Task<ActionResult> GetCarModesByCarId([FromQuery] int carId)
        {
            var carModels = await _context.CarModels.Where(t => t.CarId==carId).ToListAsync();

            return Ok(carModels);
        }

       [HttpPost]  
        [Route("delete-carModel")]
        public ActionResult DeleteCarModel([FromForm] int id)
        {

            var carModel = _context.CarModels.FirstOrDefault(p => p.Id == id);
            if (carModel == null)
            {
                return NotFound();
            }

            _context.Remove(carModel);
            _context.SaveChanges();
            return Ok(carModel);



        }

        [HttpPut]
        [Route("update-carModel")]
        public async Task<ActionResult> UpdateCarModel([FromForm] UpdateCarModelDto updateCarModelDto, [FromForm] int id)

        {
            CarModel carModel = await _context.CarModels.FirstOrDefaultAsync(p => p.Id == id);
            if (carModel == null)
            {
                return NotFound();
            }
            _mapper.Map(updateCarModelDto, carModel);


            await _context.SaveChangesAsync();

            return Ok(carModel);
        }



    }
}