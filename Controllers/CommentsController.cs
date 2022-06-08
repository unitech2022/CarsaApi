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
        [Route("get-comments")]
        public async Task<ActionResult> GetAll([FromForm] int postId)
        {
            List<ResponseComment> comments = new List<ResponseComment>();


            var data = await _myDbContext.Comments.Where(p => p.PostId == postId).ToListAsync();

            // var data = await _myDbContext.Users.Where(x => x.UserId == user.Id).AsNoTracking().ToListAsync();

            foreach (Comment variableName in data)
            {

                User user1Data = _myDbContext.Users.FirstOrDefault(p => p.Id == variableName.UserId);

                comments.Add(new ResponseComment
                {
                    Id = variableName.Id,
                    UserId = variableName.UserId,
                    CreatedAt = variableName.CreatedAt,
                    ImageUrl = user1Data.ImageUrl,
                    Phone = variableName.Phone,
                    PostId = variableName.PostId,
                    SellerId = variableName.SellerId,
                    Text = variableName.Text,
                    UserName = user1Data.FullName

                });

                // code block to be executed
            }

            return Ok(comments);
        }




        [Authorize(Roles = "user")]
        [HttpPost]
        [Route("add-comment")]
        public async Task<ActionResult> CreateComment([FromForm] Comment comment)
        {

            User user = await Functions.getCurrentUser(_httpContextAccessor, _myDbContext);
            comment.UserId = user.Id;

            await _myDbContext.Comments.AddAsync(comment);
            _myDbContext.SaveChanges();
            // var commandReadDto = _mapper.Map<PostReadDto>(coomansModel);


            return Ok(comment);


        }



        // [HttpPost]
        // [Route("delete-comment")]
        // public ActionResult DeleteComment([FromForm] int id)
        // {

        //     // var CommentModelFromRepo = _repository.GetCommentById(id);
        //     // if (CommentModelFromRepo == null)
        //     // {
        //     //     return NotFound();
        //     // }

        //     // _repository.DeleteComment(CommentModelFromRepo);
        //     // _repository.SaveChanges();
        //     // return Ok(CommentModelFromRepo.Text + "Deleted");



        // }




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