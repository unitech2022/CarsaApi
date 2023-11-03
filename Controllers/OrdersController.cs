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
using System.Text.Json;
namespace carsaApi.Controllers
{

    [Route("order")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CarsaApiContext _context;

        private readonly OrdersRepo _repository;

        private IMapper _mapper;
        public OrdersController(OrdersRepo repository, IMapper mapper, CarsaApiContext context, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;

        }


        [Authorize(Roles = "user")]
        [HttpGet]
        [Route("get-Orders")]
        public async Task<ActionResult> GetAll()
        {

            List<ResponseOrderUser> responseOrders = new List<ResponseOrderUser>();
            User user = await Functions.getCurrentUser(_httpContextAccessor, _context);
            var data = await _context.Orders.Where(x => (x.userId == user.Id)).ToListAsync();

            foreach (var item in data)
            {
                Address address = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == item.AddressId);

                responseOrders.Add(new ResponseOrderUser
                {
                    Order = item,
                    Address = address

                });



            }

            return Ok(responseOrders);
        }



        [HttpGet]
        [Route("get-all-Orders")]
        public async Task<ActionResult> GetAllOrders()
        {


            List<ResponseOrder> responseOrders = new List<ResponseOrder>();

            var data = await _context.Orders.ToListAsync();
            // List<Cart> carts=new List<Cart>();
            foreach (var item in data)
            {
                User user = await _context.Users.FindAsync(item.userId);
                Address address = _context.Addresses.FirstOrDefault(p => p.Id == item.AddressId);


                var carts = _context.Carts.Where(p => p.OrderId == item.Id).ToList();

                // foreach (var cart in carts)
                // {


                //     responseCarts.Add(new ResponseCart
                //     {
                //         productModel = product,
                //         cartModel = cart
                //     });

                // }




                responseOrders.Add(new ResponseOrder
                {
                    Order = item,
                    UserEmail = user.Email,
                    UserName = user.FullName,
                    UserPhone = user.UserName,
                    Address = address,
                    // Products=responseCarts,
                });

            }




            return Ok(responseOrders);
        }






        [Authorize(Roles = "user")]
        [HttpGet]
        [Route("get-Order-details")]
        public async Task<ActionResult> GetOrderDetails([FromForm] int orderId)
        {

            User user = await Functions.getCurrentUser(_httpContextAccessor, _context);
            var data = await _context.Carts.Where(x => (x.UserId == user.Id && x.OrderId == orderId)).ToListAsync();

            return Ok(data);

        }





        [HttpPost]
        [Route("get-Order-details-admin")]
        public async Task<ActionResult> GetOrderDetailsAdmin([FromForm] int orderId)
        {

            List<ResponseCart> responseCarts = new List<ResponseCart>();
            var data = await _context.Carts.Where(x => x.OrderId == orderId).ToListAsync();

            foreach (var item in data)
            {
                Product product = await _context.Products.FirstOrDefaultAsync(x => x.Id == item.ProductId);
                responseCarts.Add(new ResponseCart
                {
                    cartModel = item,
                    productModel = product
                });

            }

            return Ok(responseCarts);

        }



        [Authorize(Roles = "user")]
        [HttpPost]
        [Route("add-order")]
        public async Task<ActionResult> CreateOrder([FromForm] Order order)
        {
            User user = await Functions.getCurrentUser(_httpContextAccessor, _context);
            order.userId = user.Id;

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            var data = await _context.Carts.Where(x => (x.UserId == user.Id && x.OrderId == 0)).ToListAsync();
            foreach (var cart in data)
            {

                cart.OrderId = order.Id;
                await _context.SaveChangesAsync();

            }

            return Ok(order);


        }


        [Authorize(Roles = "user")]
        [HttpPost]
        [Route("delete-Order")]
        public async Task<ActionResult> DeleteOrder([FromForm] int id)
        {

            User user = await Functions.getCurrentUser(_httpContextAccessor, _context);

            Order order = _context.Orders.FirstOrDefault(p => p.Id == id && p.userId == user.Id);

            if (order == null)
            {
                return NotFound();
            }


            _repository.DeleteOrder(order);
            _repository.SaveChanges();
            var data = await _context.Carts.Where(x => (x.UserId == user.Id && x.OrderId == id)).ToListAsync();

            foreach (var cart in data)
            {

                _context.Carts.Remove(cart);
                _context.SaveChanges();
            }







            return Ok(order);



        }





        [HttpPost]
        [Route("delete-Order-admin")]
        public async Task<ActionResult> DeleteOrderAdmin([FromForm] int id)
        {

            // User user = await Functions.getCurrentUser(_httpContextAccessor, _context);

            Order order = _context.Orders.FirstOrDefault(p => p.Id == id);

            if (order == null)
            {
                return NotFound();
            }


            _repository.DeleteOrder(order);
            _repository.SaveChanges();
            var data = await _context.Carts.Where(x => x.OrderId == id).ToListAsync();

            foreach (var cart in data)
            {

                _context.Carts.Remove(cart);
                _context.SaveChanges();
            }







            return Ok(order);



        }





        [HttpPost("{id}")]
        [Route("update-Order")]
        public ActionResult UpdateCategory([FromForm] int id, [FromForm] OrderCreateDto Order)
        {
            var OrderModelFromRepo = _repository.GetOrderById(id);
            if (OrderModelFromRepo == null)
            {
                return NotFound();
            }


            _mapper.Map(Order, OrderModelFromRepo);

            _repository.UpdateOrder(OrderModelFromRepo);

            _repository.SaveChanges();

            return NoContent();

        }


        [HttpPost("{id}")]
        [Route("update-status-Order")]
        public ActionResult UpdateOrderStatus([FromForm] int id, [FromForm] int status)
        {
            var orderModelFromRepo = _repository.GetOrderById(id);
            if (orderModelFromRepo == null)
            {
                return NotFound();
            }

            orderModelFromRepo.Status = status;
            _repository.SaveChanges();

            return Ok(orderModelFromRepo);

        }


        // pagination

        [HttpGet]
        [Route("get-all-Orders-page")]
        public async Task<ActionResult> GetAllOrdersPage([FromQuery] PagingParameterModel @params)
        {


            List<ResponseOrder> responseOrders = new List<ResponseOrder>();
            List<ResponseCart> responseCarts = new List<ResponseCart>();
            var data = await _context.Orders.ToListAsync();
            // List<Cart> carts=new List<Cart>();
            foreach (var item in data)
            {
                User user = await _context.Users.FindAsync(item.userId);
                Address address = _context.Addresses.FirstOrDefault(p => p.Id == item.AddressId);

                var carts = _context.Carts.Where(p => p.OrderId == item.Id).ToList();

                foreach (var cart in carts)
                {
                    Product product = await _context.Products.FirstOrDefaultAsync(x => x.Id == cart.ProductId);

                    responseCarts.Add(new ResponseCart
                    {
                        productModel = product,
                        cartModel = cart
                    });

                }




                responseOrders.Add(new ResponseOrder
                {
                    Order = item,
                    UserEmail = user.Email,
                    UserName = user.FullName,
                    UserPhone = user.UserName,
                    Address = address,
                    // Products=responseCarts,
                });

            }




            var paginationMetadata = new PaginationMetadata(responseOrders.Count(), @params.Page, @params.ItemsPerPage);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            var items = responseOrders.Skip((@params.Page - 1) * @params.ItemsPerPage)
                                       .Take(@params.ItemsPerPage);
            return Ok(new
            {

                items = items,
                currentPage = @params.Page,
                totalPage = paginationMetadata.TotalPages
            });
        }
    }
}


