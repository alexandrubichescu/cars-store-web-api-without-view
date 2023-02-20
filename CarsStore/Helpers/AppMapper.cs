using AutoMapper;
using CarsStore.Data;
using CarsStore.Models;

namespace CarsStore.Helpers
{
    public class AppMapper: Profile
    {
        public AppMapper()
        {
            CreateMap<Cars, CarModel>().ReverseMap();
        }

    }
}
