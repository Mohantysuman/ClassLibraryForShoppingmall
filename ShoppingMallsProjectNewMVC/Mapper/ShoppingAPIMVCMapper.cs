using AutoMapper;
using ClassLibraryForShoppingmall.Model;
using ShoppingMallsProjectNewMVC.Models;

namespace ShoppingMallsProjectNewMVC.Mapper
{
    public class ShoppingAPIMVCMapper : Profile
    {
        public ShoppingAPIMVCMapper()
        {
            CreateMap<AdminModel, Shopping>().ReverseMap();
        }

    }
}
