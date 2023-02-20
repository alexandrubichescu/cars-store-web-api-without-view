using CarsStore.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace CarsStore.Repository
{
    public interface ICarRepository
    {
        Task<List<CarModel>> GetAllCarsAsync();
        Task<CarModel> GetCarByIdAsync(int id);
        Task<int> AddNewCarToDBAsync(CarModel newCar);
        Task UpdateCarAsync(int carId, CarModel carModel);
        Task DetailsUpdateCarAsync(int carId, JsonPatchDocument carModel);
        Task DeleteCarAsync(int carId);
    }
}
