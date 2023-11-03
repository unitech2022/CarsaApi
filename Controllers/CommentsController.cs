using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using carsaApi.Data;
using carsaApi.Helpers;
using carsaApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace carsaApi.Controllers
{

    [Route("comment")]
    [ApiController]
    public class CommentsController : ControllerBase
    {


        private readonly CarsaApiContext _myDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly PostsRepo _repository;

        private IMapper _mapper;
        public CommentsController(PostsRepo repository, IMapper mapper, IHttpContextAccessor httpContextAccessor, CarsaApiContext myDbContext)
        {
            _repository = repository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _myDbContext = myDbContext;

        }



        [HttpGet]
        [Route("get-comments-admin")]
        public async Task<ActionResult> GetAll([FromForm] string userId)
        {

            var data = await _myDbContext.Comments.Where(p => p.UserId == userId).ToListAsync();



            return Ok(data);
        }




        [HttpGet]
        [Route("get-comments")]
        public async Task<ActionResult> GetAll([FromForm] int postId)
        {
            List<ResponseComment> comments = new();

            var data = await _myDbContext.Comments.Where(p => p.PostId == postId).ToListAsync();

            //    var data = await _myDbContext.Users.Where(x => x.UserId == user.Id).AsNoTracking().ToListAsync();

            foreach (Comment comment in data)
            {

                Workshop workshop = _myDbContext.Workshops.FirstOrDefault(p => p.Id == comment.WorkshopId);

                if (workshop != null)
                {
                    ResponseComment responseComment = new()
                    {
                        comment = comment,
                        ImageUrlWorkShop = workshop.Image,

                        NameWorkShop = workshop.Name

                    };

                    comments.Add(responseComment);
                }

                // code block to be executed
            }

            return Ok(comments);
        }


        [HttpGet]
        [Route("get-comment-byId")]
        public async Task<ActionResult> GetCommentById([FromForm] int commentId)
        {


            Comment comment = await _myDbContext.Comments.FirstOrDefaultAsync(p => p.Id == commentId);
            Post post = await _myDbContext.Posts.FirstOrDefaultAsync(p => p.Id == comment.PostId);
            Workshop workshop = await _myDbContext.Workshops.FirstOrDefaultAsync(p => p.Id == comment.WorkshopId);
            //    var data = await _myDbContext.Users.Where(x => x.UserId == user.Id).AsNoTracking().ToListAsync();



            return Ok(new
            {
                offer = comment,
                workshop = workshop,
                post = post
            });
        }




        // [Authorize(Roles = "user")]
        [HttpPost]
        [Route("add-comment")]
        public async Task<ActionResult> CreateComment([FromForm] Comment comment)
        {

            // User user = await Functions.getCurrentUser(_httpContextAccessor, _myDbContext);
            // comment.UserId = user.Id;

            await _myDbContext.Comments.AddAsync(comment);
            _myDbContext.SaveChanges();
            // var commandReadDto = _mapper.Map<PostReadDto>(coomansModel);


            return Ok(comment);


        }

        [HttpPost]
        [Route("accept-comment")]
        public async Task<ActionResult> AcceptComment([FromForm] int id)
        {

            var comment = await _myDbContext.Comments.FirstOrDefaultAsync(t => t.Id == id);

            if (comment == null)
            {
                return NotFound();
            }
            comment.Accepted = 1;
            Post post = await _myDbContext.Posts.FirstOrDefaultAsync(t => t.Id == comment.PostId);
            post.AcceptedOfferId = comment.Id;
            _myDbContext.SaveChanges();
            return Ok(comment);



        }



        [HttpPost]
        [Route("delete-comment")]
        public async Task<ActionResult> DeleteComment([FromForm] int id)
        {

            var comment = await _myDbContext.Comments.FirstOrDefaultAsync(t => t.Id == id);

            if (comment == null)
            {
                return NotFound();
            }
            _myDbContext.Comments.Remove(comment);

            _myDbContext.SaveChanges();
            return Ok(comment);



        }




        // [HttpPost("{id}")]
        // [Route("update-comment")]
        // public ActionResult UpdateComment([FromForm] int id, [FromForm] CreateCommentDto Comment)
        // {
        //     var brandModelFromRepo = _repository.GetCommentById(id);
        //     if (brandModelFromRepo == null)
        //     {
        //         return NotFound();
        //     }


        //     _mapper.Map(Comment, brandModelFromRepo);

        //     _repository.UpdateComment(brandModelFromRepo);

        //     _repository.SaveChanges();

        //     return NoContent();

        // }

    }
}