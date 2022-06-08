using System.Collections.Generic;
using AutoMapper;
using carsaApi.Data;
using carsaApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using carsaApi.Dto;
namespace carsaApi.Controllers
{

    [Route("slider")]
    [ApiController]
    public class SlidersController : ControllerBase
    {



        private readonly SlidersRepo _repository;

        private IMapper _mapper;
        public SlidersController(SlidersRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }



        [HttpGet]
        [Route("get-sliders")]
        public ActionResult<List<Slider>> GetAll()
        {
            var bransItems = _repository.GetAll();
            return Ok(bransItems);
        }



        [HttpPost]
        [Route("add-slider")]
        public ActionResult<Slider> CreateSlider([FromForm] CreateSliderDto brand)
        {

            var coomansModel = _mapper.Map<Slider>(brand);
            _repository.AddSlider(coomansModel);
            _repository.SaveChanges();
            // var commandReadDto = _mapper.Map<CategoryReadDto>(coomansModel);


            return Ok(coomansModel);


        }



        [HttpPost]
        [Route("delete-slider")]
        public ActionResult DeleteCategory([FromForm] int id)
        {

            var categoryModelFromRepo = _repository.GetSliderById(id);
            if (categoryModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteSlider(categoryModelFromRepo);
            _repository.SaveChanges();
            return Ok(categoryModelFromRepo.Name + "Deleted");



        }




        [HttpPost("{id}")]
        [Route("update-slider")]
        public ActionResult UpdateCategory([FromForm] int id, [FromForm] CreateSliderDto category)
        {
            var brandModelFromRepo = _repository.GetSliderById(id);
            if (brandModelFromRepo == null)
            {
                return NotFound();
            }


            _mapper.Map(category, brandModelFromRepo);

            _repository.UpdateSlider(brandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();

        }

    }
}