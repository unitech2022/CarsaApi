using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using System.Linq;
using carsaApi.Data;
using carsaApi.Models;
using carsaApi.Dto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace carsaApi.Controllers
{

    [Route("category")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {



        private readonly CategoriesRepo _repository;
private readonly CarsaApiContext _context;
        private IMapper _mapper;
        public CategoriesController(CategoriesRepo repository, IMapper mapper,CarsaApiContext context)
        {
            _repository = repository;
            _mapper = mapper;
            _context=context;

        }



        [HttpGet]
        [Route("get-categories")]
        public async Task<ActionResult> GetAll()
        {
            var data = await _context.Categories.ToListAsync();
            return Ok(data);
        }

       [HttpGet]
        [Route("get-categories-work")]
        public async Task<ActionResult> GetCategoriesWork ()
        {
            var data = await _context.WorkCategories.ToListAsync();
            List<Workshop> workshops=await _context.Workshops.Where(t => t.Id==data.First().Id).ToListAsync();
            return Ok(data);
        }


        [HttpPost]
        [Route("add-category")]
        public ActionResult<Category> CreateCategory([FromForm] CreateCategoryDto brand)
        {

            var coomansModel = _mapper.Map<Category>(brand);
            _repository.AddCategory(coomansModel);
            _repository.SaveChanges();
            // var commandReadDto = _mapper.Map<CategoryReadDto>(coomansModel);


            return Ok(coomansModel);


        }

       [HttpPost]
        [Route("add-category-work")]
        public ActionResult<Category> CreateCategoryWork([FromForm] WorkshopCategory category)
        {

            
            _repository.AddCategoryWork(category);
            _repository.SaveChanges();
            // var commandReadDto = _mapper.Map<CategoryReadDto>(coomansModel);


            return Ok(category);


        }


        [HttpPost]
        [Route("delete-Category")]
        public async Task<ActionResult> DeleteCategory([FromForm] int id)
        {

            var categoryModelFromRepo = _repository.GetCategoryById(id);
            if (categoryModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteCategory(categoryModelFromRepo);
            _repository.SaveChanges();
            var data= _context.Products.Where(p => p.CategoryId==id).ToList();
            foreach(var item in data){

               _context.Products.Remove(item);
               await   _context.SaveChangesAsync();

            }
            return Ok(categoryModelFromRepo.Name + "Deleted");



        }




        [HttpPost("{id}")]
        [Route("update-Category")]
        public ActionResult UpdateCategory([FromForm] int id, [FromForm] CreateCategoryDto category)
        {
            var brandModelFromRepo = _repository.GetCategoryById(id);
            if (brandModelFromRepo == null)
            {
                return NotFound();
            }


            _mapper.Map(category, brandModelFromRepo);

            _repository.UpdateCategory(brandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();

        }

    }
}