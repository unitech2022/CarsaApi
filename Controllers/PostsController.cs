using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using carsaApi.Data;
using carsaApi.Helpers;
using carsaApi.Models;
using carsaApi.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace carsaApi.Controllers
{

    [Route("post")]
    [ApiController]
    public class PostsController : ControllerBase
    {


        private readonly CarsaApiContext _myDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly PostsRepo _repository;

        private IMapper _mapper;
        public PostsController(PostsRepo repository, IMapper mapper, IHttpContextAccessor httpContextAccessor, CarsaApiContext myDbContext)
        {
            _repository = repository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _myDbContext = myDbContext;

        }


        // [Authorize(Roles = "user")]
        [HttpGet]
        [Route("get-Posts")]
        public async Task<ActionResult> GetAll()
        {
            // User user = await Functions.getCurrentUser(_httpContextAccessor, _myDbContext);
            var data = await _myDbContext.Posts.ToListAsync();
            List<ResponsePost> responsePosts = new List<ResponsePost>();
            foreach (var item in data)
            {

                User UserData = _myDbContext.Users.FirstOrDefault(p => p.Id == item.UserId);

                if (UserData != null)
                {
                    responsePosts.Add(
                                       new ResponsePost
                                       {
                                           ImageUrlUser = UserData.ImageUrl,
                                           NameUser = UserData.FullName,
                                           Post = item
                                       }
                                    );

                }
                else
                {
                    responsePosts.Add(
                   new ResponsePost
                   {
                       ImageUrlUser = "",
                       NameUser = "",
                       Post = item
                   }
                );
                }


            }
            return Ok(responsePosts);
        }




        // [Authorize(Roles = "user")]
        [HttpGet]
        [Route("get-my-Posts")]
        public async Task<ActionResult> GetMyPosts([FromForm] string userId)
        {

            var data = await _myDbContext.Posts.Where(p => p.UserId == userId).ToListAsync();
            // List<ResponsePost> responsePosts = new List<ResponsePost>();
            // foreach (var item in data)
            // {

            //     User UserData = _myDbContext.Users.FirstOrDefault(p => p.Id == item.UserId);
            //     responsePosts.Add(
            //        new ResponsePost
            //        {
            //            ImageUrlUser = UserData.ImageUrl,
            //            NameUser = UserData.FullName,
            //            Post = item
            //        }
            //     );

            // }

            return Ok(data);
        }


         [HttpGet]
        [Route("get-Posts-admin")]
        public async Task<ActionResult> GePostsAdmin()
        {

            var data = await _myDbContext.Posts.ToListAsync();
           

            return Ok(data);
        }



        // [Authorize(Roles = "user")]
        [HttpPost]
        [Route("add-post")]
        public async Task<ActionResult> CreatePost([FromForm] Post post)
        {

            // User user = await Functions.getCurrentUser(_httpContextAccessor, _myDbContext);
            // post.UserId = user.Id;

            await _myDbContext.Posts.AddAsync(post);
            _myDbContext.SaveChanges();
            // var commandReadDto = _mapper.Map<PostReadDto>(coomansModel);


            return Ok(post);


        }


        // [Authorize(Roles = "user")]
        [HttpPost]
        [Route("delete-Post")]
        public async Task<ActionResult> DeletePost([FromForm] int id)
        {

            // User user = await Functions.getCurrentUser(_httpContextAccessor, _myDbContext);
            Post post = _myDbContext.Posts.FirstOrDefault(p => p.Id == id);

            if (post == null)
            {

                return NotFound();
            }


            _myDbContext.Posts.Remove(post);
            _myDbContext.SaveChanges();
            return Ok(post);



        }

  // [Authorize(Roles = "user")]
       
        [HttpPost("get-post-byId")]
        public async Task<ActionResult> GetPostById([FromForm] int id,[FromForm] string userId)
        {
          bool isOffer=false;
            var post =await _myDbContext.Posts.FirstOrDefaultAsync(t => t.Id ==id);
            if (post == null)
            {
                return NotFound();
            }
            User userDetail =await _myDbContext.Users.FirstOrDefaultAsync(t => t.Id ==post.UserId);

             Comment offer=await _myDbContext.Comments.FirstOrDefaultAsync(t=> t.PostId==post.Id&&t.UserId==userId);
          if(offer==null){
            isOffer=false;
          }else{
            isOffer=true;
          }

            return Ok(new {
                isOffer=isOffer,
                post =post,
                user =userDetail
            });

        }


        [HttpPost]
        [Route("update-post-status")]
        public async Task<ActionResult> UpdatePostStatus([FromForm] int id, [FromForm] int status)
        {

            // User user = await Functions.getCurrentUser(_httpContextAccessor, _myDbContext);
            Post post =await  _myDbContext.Posts.FirstOrDefaultAsync(p => p.Id == id);

            if (post == null)
            {

                return NotFound();
            }

            post.AcceptedOfferId = status;

            _myDbContext.SaveChanges();
            return Ok(post);

        }


        // [Authorize(Roles = "user")]
        [HttpPost("{id}")]
        [Route("update-post")]
        public async Task<ActionResult> UpdatePost([FromForm] int id, [FromForm] CreatePostDto Post)
        {
            // User user = await Functions.getCurrentUser(_httpContextAccessor, _myDbContext);
            var brandModelFromRepo = _repository.GetPostById(id);
            if (brandModelFromRepo == null)
            {
                return NotFound();
            }


            _mapper.Map(Post, brandModelFromRepo);

            _repository.UpdatePost(brandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();

        }

   
   
   
    }
}