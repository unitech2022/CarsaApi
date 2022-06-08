using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using carsaApi.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using carsaApi.Profiles;
using carsaApi.Models;
using Microsoft.AspNetCore.Identity;
using carsaApi.Notification;
using CorePush.Apple;
using CorePush.Google;

namespace carsaApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


         //   notification
            services.AddTransient<INotificationService, NotificationService>();
            services.AddHttpClient<FcmSender>();
            services.AddHttpClient<ApnSender>();

            // Configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("FcmNotification");
            services.Configure<FcmNotificationSetting>(appSettingsSection);
// ---------------



            services.AddDbContext<CarsaApiContext>(otp =>
             otp.UseSqlServer(Configuration.GetConnectionString("CarsaApiConnection")));



            services.AddCors(options =>

               {

                   options.AddPolicy(

                   name: "AllowOrigin",

                   builder =>
                   {

                       builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();

                   });

               });


            services.AddControllers();
            var config = new AutoMapper.MapperConfiguration(cfg =>
                        {
                            cfg.AddProfile(new CarsaApoProfile());
                        });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            // services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<BrandsRepo>();
            services.AddScoped<CategoriesRepo>();
            services.AddScoped<ProductsRepo>();
            services.AddScoped<SlidersRepo>();
            services.AddScoped<CartsRepo>();
            services.AddScoped<OrdersRepo>();
            services.AddScoped<PostsRepo>();
            services.AddScoped<CommentsRepo>();
            services.AddScoped<FavRepo>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "carsaApi", Version = "v1" });
            });

            // For Identity  
            services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<CarsaApiContext>()
                    .AddDefaultTokenProviders();


            //auth
            // Adding Authentication  
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            // Adding Jwt Bearer  
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ClockSkew = TimeSpan.Zero,



                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"])),
                };
            });

            services.AddSignalR();

        }

        //auth



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // app.UseSwagger();
                // app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "carsaApi v1"));
            }

            // app.UseHttpsRedirection();
            app.UseCors("AllowOrigin");
            app.UseRouting();

            app.UseAuthentication();


            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
