using CafeApp.Data.Repositories;
using CafeApp.Data.Repository;
using CafeApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CafeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRepository<Restaurant> restaurantRepository;

        public RestaurantController(IRepository<Restaurant> restaurantRepository)
        {
            this.restaurantRepository = restaurantRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetAllRestaurants()
        {
            var restaurants = await restaurantRepository.GetAll();
            return Ok(restaurants);
        }
    }
}
