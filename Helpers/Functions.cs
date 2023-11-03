using carsaApi.Dto;
using carsaApi.Data;
using carsaApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace carsaApi.Helpers{



    class Functions {
       public static Functions slt = new Functions();

           public static async Task<User> getCurrentUser(IHttpContextAccessor _httpContextAccessor, CarsaApiContext _context)
    {
        var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        var user = await _context.Users.FindAsync(userId);
        return user;
    }




    
    public async Task<bool> SendNotificationAsync(List<string> userIds, string title, string body, CarsaApiContext context)
    {

        List<string> tokens = 
             userIds
         .Select(x => context.Users.Where(u=>u.Id == x).First().DeviceToken)
          .ToList();

        using (var client = new HttpClient())
        {
            var firebaseOptionsServerId = "AAAA7cUm9b0:APA91bH6E2cQ03oqOglGx7KZGS84bt4sreEAVfXEZ1VgbwTeTBShYsYGSWw8kPb_tNVMWYIHdZNlOz7tlRQeZljfCYF6IN9wLGXvmPbUrTRoEcwp186fRj-6GgjGZiWgKtQSiCkpiRdF";
            var firebaseOptionsSenderId = "1021214913981";

            client.BaseAddress = new Uri("https://fcm.googleapis.com");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization",
                $"key={firebaseOptionsServerId}");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Sender", $"id={firebaseOptionsSenderId}");
            var data = new
            {
                registration_ids = tokens,
                notification = new
                {
                    body = body,
                    title = title,
                },
                data=new  {
                    orderId =1
                },
                priority = "high"
            };

            var json = JsonConvert.SerializeObject(data);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var result = await client.PostAsync("/fcm/send", httpContent);
            return result.StatusCode.Equals(HttpStatusCode.OK);
        }
    }

  public static async Task<bool> PushNotificationSingle(CarsaApiContext _context, string userId, string title, string body)
    {
        User user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
      
          




        string token = user.DeviceToken;
        using (var client = new HttpClient())
        {
            var firebaseOptionsServerId = "AAAA7cUm9b0:APA91bH6E2cQ03oqOglGx7KZGS84bt4sreEAVfXEZ1VgbwTeTBShYsYGSWw8kPb_tNVMWYIHdZNlOz7tlRQeZljfCYF6IN9wLGXvmPbUrTRoEcwp186fRj-6GgjGZiWgKtQSiCkpiRdF";

            client.BaseAddress = new Uri("https://fcm.googleapis.com");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization",
                $"key={firebaseOptionsServerId}");
            var data = new
            {
                to = token,
                notification = new
                {
                    body = body,
                    title = title,
                },
                click_action = "FLUTTER_NOTIFICATION_CLICK",
                priority = "high",

            };


            var json = JsonConvert.SerializeObject(data);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await client.PostAsync("/fcm/send", httpContent);

            return result.StatusCode.Equals(HttpStatusCode.OK);
        }
    }



 public static double GetDistance(double Lat1, 
                  double Long1, double Lat2, double Long2)
    {
       
        double dDistance = Double.MinValue;
        double dLat1InRad = Lat1 * (Math.PI / 180.0);
        double dLong1InRad = Long1 * (Math.PI / 180.0);
        double dLat2InRad = Lat2 * (Math.PI / 180.0);
        double dLong2InRad = Long2 * (Math.PI / 180.0);

        double dLongitude = dLong2InRad - dLong1InRad;
        double dLatitude = dLat2InRad - dLat1InRad;

        // Intermediate result a.
        double a = Math.Pow(Math.Sin(dLatitude / 2.0), 2.0) + 
                   Math.Cos(dLat1InRad) * Math.Cos(dLat2InRad) * 
                   Math.Pow(Math.Sin(dLongitude / 2.0), 2.0);

        // Intermediate result c (great circle distance in Radians).
        double c = 2.0 * Math.Asin(Math.Sqrt(a));

        // Distance.
        // const Double kEarthRadiusMiles = 3956.0;
        const Double kEarthRadiusKms = 6376.5;
        dDistance = kEarthRadiusKms * c;

        return dDistance;
    }

    }

    
}