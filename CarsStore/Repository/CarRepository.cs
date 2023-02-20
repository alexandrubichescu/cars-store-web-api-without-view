using AutoMapper;
using CarsStore.Data;
using CarsStore.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace CarsStore.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly CarStoreContext _context;
        private readonly IMapper _mapper;

        public CarRepository(CarStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<CarModel>> GetAllCarsAsync()
        {
            var records = await _context.Cars.ToListAsync();
            return _mapper.Map<List<CarModel>>(records);
        }
        public async Task<CarModel> GetCarByIdAsync(int carId)
        {
            var records = await _context.Cars.FindAsync(carId);
            return _mapper.Map<CarModel>(records);
        }
        public async Task<int> AddNewCarToDBAsync(CarModel newCar)
        {
            var car = new Cars()
            {
                Manufacturer = newCar.Manufacturer!,
                Model = newCar.Model!
            };
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return car.Id;
        }
        public async Task UpdateCarAsync(int carId, CarModel carModel)
        {
            var car = new Cars()  // loveste baza de date doar odata
            {
                Id = carId,
                Manufacturer = carModel.Manufacturer!,
                Model = carModel.Model!
            };
            _context.Cars.Update(car);
            await _context.SaveChangesAsync();
        }
        public async Task DetailsUpdateCarAsync(int carId, JsonPatchDocument carModel)
        {
            var car = await _context.Cars.FindAsync(carId);
            if (car != null)
            {
                carModel.ApplyTo(car);
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteCarAsync(int carId)
        {
            var car = new Cars() { Id = carId };
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
        }
    }
}
