using AutoMapper;
using carsaApi.Dto;

using carsaApi.Models;

namespace carsaApi.Profiles
{


    public class CarsaApoProfile : Profile
    {

        public CarsaApoProfile()
        {
            CreateMap<CreateBrandDto, Brand>();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<CreateProductDto, Product>();
            CreateMap<CreateSliderDto, Slider>();
            CreateMap<CreateCartDto, Cart>();
            CreateMap<OrderCreateDto, Order>();
            CreateMap<CreatePostDto, Post>();
            CreateMap<CreateCommentDto, Comment>();
            CreateMap<CreateNeedDto, Need>();

            CreateMap<CreateFavoriteDto, ReadFavoriteDto>();
            CreateMap<CreateFavoriteDto, Favorite>();

             CreateMap<CreateSuggestions, Suggestions>();

 CreateMap<CreateSittingDto, Sitting>();

            //User
            CreateMap<UserForRegister, User>();


            CreateMap<User, UserDetailResponse>();
            CreateMap<UserForUpdate, User>();
            CreateMap<DriverForRegister, User>();

            CreateMap<DriverForRegister, Driver>();


            // CreateMap<CommandCreateDto, Command>();
            // CreateMap<CommandUpdateDto, Command>();
            // CreateMap<Command, CommandUpdateDto>();
            // CreateMap<Category, CategoryReadDto>();
            // CreateMap<CreateCategory, Category>();
            // CreateMap<SubCategoryCreateDto, Category>();
            // CreateMap<CategoryUpdateDto, Category>();


            // CreateMap<SubCategoryUpdateDto, SubCategory>();

            //  CreateMap<CreateAdds, Adds>();
            // CreateMap<ReadAddsDto, Adds>();
            //  CreateMap<AddsUpdateDto, Adds>();





        }

    }

}