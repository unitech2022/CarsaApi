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
using System.Text.Json;
using System;

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
            var bransItems = await _context.Products.Where(x => x.BrandId == categoryId ).ToListAsync();
            return Ok(bransItems);
        }


       [HttpGet]
        [Route("get-product-by-id")]
        public async Task<ActionResult> GetProductByID([FromForm] int id)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if(product==null){
                return NotFound();
            }
            return Ok(product);
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
        [Route("add-product-list")]
        public ActionResult<Product> AddProducts([FromForm] IEnumerable<Product> products)
        {
            // Console.WriteLine("."+products.Count);
            foreach (var item in products)
            {
                var coomansModel = _mapper.Map<Product>(item);
            _repository.AddProduct(coomansModel);
            _repository.SaveChanges();
            // var commandReadDto = _mapper.Map<CategoryReadDto>(coomansModel);


           
            }
            
            return Ok(products);

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







        // pagination

        [HttpGet]
        [Route("get-products-admin")]
        public async Task<ActionResult> GetAllAdmin([FromQuery]PagingParameterModel  @params)
        {
            var bransItems = await _context.Products.ToListAsync();
                 var paginationMetadata = new PaginationMetadata(bransItems.Count(), @params.Page, @params.ItemsPerPage);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            var items =  bransItems.Skip((@params.Page - 1) * @params.ItemsPerPage)
                                       .Take(@params.ItemsPerPage);
    return Ok(new {

        items=items,
        currentPage=@params.Page,
        totalPage=paginationMetadata.TotalPages
    });

        }



        // user 
          [HttpGet]
        [Route("get-products-by-category-page")]
        public async Task<ActionResult> GetAllByCategoryPage([FromForm] int categoryId,[FromForm]PagingParameterModel  @params)
        {
            var bransItems = await _context.Products.Where(x => x.CategoryId == categoryId).ToListAsync();
              var paginationMetadata = new PaginationMetadata(bransItems.Count(), @params.Page, @params.ItemsPerPage);
             Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            var items =  bransItems.Skip((@params.Page - 1) * @params.ItemsPerPage)
                                       .Take(@params.ItemsPerPage);
    return Ok(new {

        items=items,
        currentPage=@params.Page,
        totalPage=paginationMetadata.TotalPages
    });
        }





          [HttpGet]
        [Route("get-products-by-barnd-page")]
        public async Task<ActionResult> GetAllByBrand([FromForm] int categoryId ,[FromForm] int carModeId,[FromForm]PagingParameterModel  @params)
        {
            var bransItems = await _context.Products.Where(x => x.CategoryId == categoryId && x.CarModelId == carModeId).ToListAsync();
             var paginationMetadata = new PaginationMetadata(bransItems.Count(), @params.Page, @params.ItemsPerPage);
             Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            var items =  bransItems.Skip((@params.Page - 1) * @params.ItemsPerPage)
                                       .Take(@params.ItemsPerPage);
    return Ok(new {
        items=items,
        currentPage=@params.Page,
        totalPage=paginationMetadata.TotalPages
    });
        }
        }

    }
