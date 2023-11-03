using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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




    [ApiController]
    public class UsersController : Controller
    {




        private readonly CarsaApiContext _context;
        private readonly IMapper _mapper;
        IHttpContextAccessor _httpContextAccessor;


        public UsersController(IMapper mapper, CarsaApiContext context, IHttpContextAccessor httpContextAccessor

             )
        {
            this._context = context;
            this._mapper = mapper;
            _httpContextAccessor = httpContextAccessor;

        }









        [Authorize(Roles = "user,driver")]
        [HttpPost("user/update")]
        public async Task<ActionResult> UpdateUserAsync([FromForm] UserForUpdate userForUpdate)
        {
            User user = await Functions.getCurrentUser(_httpContextAccessor, _context);
            if (userForUpdate.FullName != null)
            {
                user.FullName = userForUpdate.FullName;
                await _context.SaveChangesAsync();
            }
            if (userForUpdate.Email != null)
            {
                user.Email = userForUpdate.Email;
                await _context.SaveChangesAsync();
            }
            if (userForUpdate.Phone != null)
            {
                user.PhoneNumber = userForUpdate.Phone;
                await _context.SaveChangesAsync();
            }

            if (userForUpdate.ImageUrl != null)
            {
                // var orders = await _context.Orders.Where(x => x.UserImage == user.ImageUrl).OrderByDescending(x => x.Id).ToListAsync();
                // orders.ForEach((order) =>
                // {
                //     order.UserImage = userForUpdate.ImageUrl;
                // });

                user.ImageUrl = userForUpdate.ImageUrl;
                await _context.SaveChangesAsync();
            }
            if (userForUpdate.DeviceToken != null)
            {
                user.DeviceToken = userForUpdate.DeviceToken;
                await _context.SaveChangesAsync();
            }
            return Ok(userForUpdate);
        }



        [Authorize(Roles = "user,driver")]
        [HttpPost("user/detail")]
        public async Task<ActionResult> Details()
        {

            User user = await Functions.getCurrentUser(_httpContextAccessor, _context);
            int Comments = await _context.Comments.Where(x => x.Text == user.Id && x.Text != null).CountAsync();

            int Orders = await _context.Orders.Where(x => x.userId == user.Id).CountAsync();

            int fav = await _context.Favorites.Where(x => x.UserId == user.Id).CountAsync();
            int cart = await _context.Carts.Where(x => x.UserId == user.Id).CountAsync();

            var driver = await _context.Drivers.Where(x => x.UserId == user.Id).AsNoTracking().FirstOrDefaultAsync();
            return Ok(new
            {
                user = user,
                fav = fav,
                Comments = Comments,
                cart = cart,
                Orders = Orders
            });

        }


 
//  public string Id { get; set; }
//         public string UserName { get; set; }
//         public string FullName { get; set; }
//         public string ImageUrl { get; set; }
//         public string Status { get; set; }
//         public string Role { get; set; }



        [HttpGet("user/get-all")]
        public async Task<ActionResult> GetAllUsers()
        {

            List<UserDetailResponse> users = new List<UserDetailResponse> { };
            var data = await _context.Users.ToListAsync();
            foreach (var item in data)
            {
                
                users.Add( new UserDetailResponse
                {
                    FullName = item.FullName,
                   
                    UserName = item.UserName,
                  
                    ImageUrl = item.ImageUrl,
                   
                   Id=item.Id,
                   Role=item.Role,
                   Status=item.Status,
                   CreatedAt=item.CreatedAt

                });
            }



            return Ok(users);
        }




          //support

        [HttpPost("support/add-message")]
        public async Task<ActionResult> AddMessage([FromForm]Support support)
        {
             await _context.Supports.AddAsync(support);
            if (support.Sender == "admin") {

                
              await  Functions.slt.SendNotificationAsync(new List<string>() { support.UserId }, "لديك رسالة جديدة", support.Message, _context);
            } else {
                

              Sitting suggestions=_context.Sittings.FirstOrDefault(x => x.Name=="replay");
                 if(suggestions.value=="true"){
                   Support newSupport=new Support{
                    UserId=support.UserId,
                    Message="شكرا لتواصلك معنا سوف يتم الرد عليك في أسرع وقت ",
                    Sender="admin",
            
                   };
                    await _context.Supports.AddAsync(newSupport);
             await  Functions.slt.SendNotificationAsync(new List<string>() { support.UserId }, "لديك رسالة جديدة", support.Message, _context);
                 }
            }
            await _context.SaveChangesAsync();
            
            return Ok(true);
        }



        

        [HttpPost("support/get-user-messages")]
        public async Task<ActionResult> GetMessages([FromForm] string UserId)
        {
            var messages = await _context.Supports.Where(x => x.UserId == UserId).ToListAsync();
            
            return Ok(messages);
        }
        


         [HttpPost("support/get-user-messages-admin")]
        public async Task<ActionResult> GetMessagesAdmin([FromForm] string UserId)
        {
             List<ResponseMessage> responseMessages=new List<ResponseMessage>();
            var messages = await _context.Supports.Where(x => x.UserId == UserId).ToListAsync();

             foreach (var item in messages)
            {
                User user=_context.Users.FirstOrDefault(x => x.Id == item.UserId);

             UserDetailResponse sender=   _mapper.Map<UserDetailResponse>(user);

                responseMessages.Add(new ResponseMessage{
                    Sender =sender,
                    Support =item
                });
            }
            
            return Ok(responseMessages);
        }
        



          [HttpPost("support/get-all-messages")]
        public async Task<ActionResult> GetAllMessages([FromForm] string UserId)
        {
           List<ResponseMessage> responseMessages=new List<ResponseMessage>();

            var messages = await _context.Supports.Where(x=> x.Sender !="admin").ToListAsync();

            foreach (var item in messages)
            {
                User user=_context.Users.FirstOrDefault(x => x.Id == item.UserId);

             UserDetailResponse sender=   _mapper.Map<UserDetailResponse>(user);

                responseMessages.Add(new ResponseMessage{
                    Sender =sender,
                    Support =item
                });
            }
            
            return Ok(responseMessages);
        }

        [HttpPost("support/close-user-chat")]
        public async Task<ActionResult> ClearMessages([FromForm] string UserId)
        {
            var messages = await _context.Supports.Where(x => x.UserId == UserId).ToListAsync();
             _context.Supports.RemoveRange(messages);
            await _context.SaveChangesAsync();
            return Ok(true);
        }

    }
}