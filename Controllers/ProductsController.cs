using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using carsaApi.Data;
using carsaApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using carsaApi.Dto;
namespace carsaApi.Controllers
{

    [Route("product")]
    [ApiController]
    public class ProductsController : ControllerBase
    {



        private readonly ProductsRepo _repository;

        private readonly CarsaApiContext _context;

        private IMapper _mapper;
        public ProductsController(ProductsRepo repository, IMapper mapper, CarsaApiContext context)
        {
            _repository = repository;
            _mapper = mapper;
            _context = context;

        }



        [HttpGet]
        [Route("get-products")]
        public async Task<ActionResult> GetAll()
        {
            var bransItems = await _context.Products.ToListAsync();
            return Ok(bransItems);
        }


   [HttpGet]
        [Route("get-products-slider")]
        public async Task<ActionResult> GetAllSlider()
        {
            var bransItems = await _context.Products.Where(p =>p.OfferId==1).ToListAsync();
            return Ok(bransItems);
        }




        [HttpGet]
        [Route("search-products")]
        public async Task<ActionResult> SearchProduct([FromForm] string name)
        {
            var bransItems = await _context.Products.Where(p => p.Name.Contains(name)).ToListAsync();
            return Ok(bransItems);
        }



        [HttpGet]
        [Route("get-products-by-category")]
        public async Task<ActionResult> GetAllByCategory([FromForm] int categoryId)
        {
            var bransItems = await _context.Products.Where(x => x.CategoryId == categoryId).ToListAsync();
            return Ok(bransItems);
        }



   [HttpGet]
        [Route("get-products-by-barnd")]
        public async Task<ActionResult> GetAllByBrand([FromForm] int categoryId)
        {
            var bransItems = await _context.Products.Where(x => x.BrandId == categoryId).ToListAsync();
            return Ok(bransItems);
        }


        [HttpPost]
        [Route("add-product")]
        public ActionResult<Product> CreateCategory([FromForm] CreateProductDto product)
        {

            var coomansModel = _mapper.Map<Product>(product);
            _repository.AddProduct(coomansModel);
            _repository.SaveChanges();
            // var commandReadDto = _mapper.Map<CategoryReadDto>(coomansModel);


            return Ok(coomansModel);


        }



        [HttpPost]
        [Route("delete-product")]
        public ActionResult DeleteCategory([FromForm] int id)
        {

            var categoryModelFromRepo = _repository.GetProductById(id);
            if (categoryModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteProduct(categoryModelFromRepo);
            _repository.SaveChanges();
            return Ok(categoryModelFromRepo.Name + "Deleted");



        }




        [HttpPost("{id}")]
        [Route("update-product")]
        public ActionResult UpdateCategory([FromForm] int id, [FromForm] CreateProductDto productDto)
        {
            var productModelFromRepo = _repository.GetProductById(id);
            if (productModelFromRepo == null)
            {
                return NotFound();
            }


            _mapper.Map(productDto, productModelFromRepo);

            _repository.UpdateProduct(productModelFromRepo);

            _repository.SaveChanges();

            return NoContent();

        }

    }
}