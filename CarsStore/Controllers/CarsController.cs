using CarsStore.Models;
using CarsStore.Repository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CarsStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : Controller
    {
        private readonly ICarRepository _carRepository;

        public CarsController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllCars()
        {
            var cars = await _carRepository.GetAllCarsAsync();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarById([FromRoute] int id)
        {
            var carId = await _carRepository.GetCarByIdAsync(id);
            if (carId == null)
            {
                return NotFound();
            }
            return Ok(carId);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddNewCarToDB([FromBody] CarModel brand)
        {
            var id = await _carRepository.AddNewCarToDBAsync(brand);
            return CreatedAtAction(nameof(GetCarById), new { id = id, controller = "cars" }, id);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar([FromBody] CarModel carModel, [FromRoute] int id)
        {
             await _carRepository.UpdateCarAsync(id, carModel);
            return Ok();
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> DetailsUpdateCar([FromBody] JsonPatchDocument carModel, [FromRoute] int id)
        {
            await _carRepository.DetailsUpdateCarAsync(id, carModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar([FromRoute] int id)
        {
            await _carRepository.DeleteCarAsync(id);
            return Ok();
        }

        [HttpGet("details")]
        public IActionResult Details()
        {
           var auto = _carRepository.GetAllCarsAsync();
           if (auto == null)
               return NotFound();
           return View(auto);
        }
    }
}
