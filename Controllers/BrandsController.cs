using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using carsaApi.Data;
using carsaApi.Dto;
using carsaApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace carsaApi.Controllers
{

    [Route("brand")]
    [ApiController]
    public class BrandsController : ControllerBase
    {


        private readonly CarsaApiContext _context;
        private readonly BrandsRepo _repository;

        private IMapper _mapper;
        public BrandsController(BrandsRepo repository, IMapper mapper, CarsaApiContext context)
        {
            _repository = repository;
            _mapper = mapper;
            _context = context;

        }



        [HttpGet]
        [Route("get-brands")]
        public async Task<ActionResult> GetAll()
        {
            var data = await _context.Brands.ToListAsync();
            // var bransItems = _repository.GetAll();
            return Ok(data);
        }



        [HttpPost]
        [Route("add-barnd")]
        public ActionResult<Brand> CreateCategory([FromForm] CreateBrandDto brand)
        {

            var coomansModel = _mapper.Map<Brand>(brand);
            _repository.CreateBrand(coomansModel);
            _repository.SaveChanges();
            // var commandReadDto = _mapper.Map<CategoryReadDto>(coomansModel);


            return Ok(coomansModel);


        }



        [HttpPost]
        [Route("delete-brand")]
        public ActionResult DeleteBrand([FromForm] int id)
        {

            var categoryModelFromRepo = _repository.GetBrandById(id);
            if (categoryModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteBrand(categoryModelFromRepo);
            _repository.SaveChanges();
            return Ok(categoryModelFromRepo.Name + "Deleted");



        }




        [HttpPost("{id}")]
        [Route("update-brand")]
        public ActionResult UpdateCategory([FromForm] int id, [FromForm] CreateBrandDto brand)
        {
            var brandModelFromRepo = _repository.GetBrandById(id);
            if (brandModelFromRepo == null)
            {
                return NotFound();
            }


            _mapper.Map(brand, brandModelFromRepo);

            _repository.UpdateBrand(brandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();

        }

    }
}