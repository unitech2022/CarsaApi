using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using System.Collections.Generic;
using carsaApi.Data;
using carsaApi.Dto;
using carsaApi.Helpers;
using carsaApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace carsaApi.Controllers
{


    [Route("fav")]
    [ApiController]

    public class FavoriteController : ControllerBase
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CarsaApiContext _context;
        private readonly FavRepo _repository;
        private IMapper _mapper;
        public FavoriteController(FavRepo repository, IMapper mapper, CarsaApiContext context, IHttpContextAccessor httpContextAccessor)
        {

            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _repository = repository;

        }


        [Authorize(Roles = "user")]
        [HttpGet]
        [Route("get-Favorites")]
        public async Task<ActionResult> GetAll()
        {

            List<ResponseFavorite>responseFavorite=new List<ResponseFavorite>();

            User user = await Functions.getCurrentUser(_httpContextAccessor, _context);
            var data = await _context.Favorites.Where(x => x.UserId == user.Id).ToListAsync();
            // foreach (var item in data)
            // {
            //     Product product=await _context.Products.FirstOrDefaultAsync(x => x.Id == item.ProductId);     
            //      responseFavorite.Add(new ResponseFavorite{
            //         Favorite=item,
            //         Product=product
            // });
                
            // }

            return Ok(data);
        }


        [Authorize(Roles = "user")]
        [HttpPost]
        [Route("add-favorite")]
        public async Task<ActionResult<Favorite>> CreateFavoriteAsync([FromForm] int productId)
        {

            User user = await Functions.getCurrentUser(_httpContextAccessor, _context);


            Favorite favorite1 = _context.Favorites.FirstOrDefault(p => p.ProductId == productId);

            if (favorite1 == null)
            {

                Product product = _context.Products.FirstOrDefault(p => p.Id == productId);
                if (product == null)
                {

                    return NotFound();
                }

                Favorite favorite = new Favorite
                {
                    BrandId = product.BrandId,
                    CategoryId = product.CategoryId,
                    Detail = product.Detail,
                    Image = product.Image,
                    Name = product.Name,
                    Price = product.Price,
                    IsCart = false,
                    IsFav = true,
                    ProductId = productId,
                    SellerId = product.SellerId,
                    Status = product.Status,
                    UserId = user.Id,

                };
                product.IsFav = true;
                await _context.SaveChangesAsync();
                await _context.Favorites.AddAsync(favorite);

                _context.SaveChanges();
                // var commandReadDto = _mapper.Map<FavoriteReadDto>(coomansModel);

                ResponseFav response = new ResponseFav
                {
                    status=true,
                    Message = "تمت الاضافة بنجاح",

                    Favorite = favorite


                };

                return Ok(response);

            }

            else
            {

                Product product = _context.Products.FirstOrDefault(p => p.Id == favorite1.ProductId);
                product.IsFav = false;

                await _context.SaveChangesAsync();
                _repository.DeleteFavorites(favorite1);
                _repository.SaveChanges();

                ResponseFav response = new ResponseFav
                {
                    status=false,
                    Message = "تمت الحذف بنجاح",

                    Favorite = favorite1


                };

                return Ok(response);

            }



        }


        [Authorize(Roles = "user")]
        [HttpPost]
        [Route("delete-Favorite")]
        public async Task<ActionResult> DeleteFavorite([FromForm] int id)
        {

            var FavoriteModelFromRepo = _repository.GetFavoritesById(id);
            if (FavoriteModelFromRepo == null)
            {
                return NotFound();
            }
            Product product = _context.Products.FirstOrDefault(p => p.Id == FavoriteModelFromRepo.ProductId);
            product.IsFav = false;

            await _context.SaveChangesAsync();
            _repository.DeleteFavorites(FavoriteModelFromRepo);
            _repository.SaveChanges();
            return Ok(FavoriteModelFromRepo.Name + "تم حذف");



        }



        [Authorize(Roles = "user")]
        [HttpPost("{id}")]
        [Route("update-Favorite")]
        public ActionResult UpdateFavorite([FromForm] int id, [FromForm] CreateFavoriteDto Favorite)
        {
            var favoriteModelFromRepo = _repository.GetFavoritesById(id);
            if (favoriteModelFromRepo == null)
            {
                return NotFound();
            }

            Product product = _context.Products.FirstOrDefault(p => p.Id == favoriteModelFromRepo.ProductId);


            _mapper.Map(Favorite, favoriteModelFromRepo);

            _repository.UpdateFavorites(favoriteModelFromRepo);

            _repository.SaveChanges();

            return NoContent();

        }

    }
}