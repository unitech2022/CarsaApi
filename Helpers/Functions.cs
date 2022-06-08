

using System.Security.Claims;
using System.Threading.Tasks;
using carsaApi.Data;
using carsaApi.Models;
using Microsoft.AspNetCore.Http;

namespace carsaApi.Helpers{



    class Functions {


           public static async Task<User> getCurrentUser(IHttpContextAccessor _httpContextAccessor, CarsaApiContext _context)
    {
        var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        var user = await _context.Users.FindAsync(userId);
        return user;
    }
    }
}