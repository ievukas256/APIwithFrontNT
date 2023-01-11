using Microsoft.AspNetCore.Mvc;

namespace APIwithFrontNT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomesController : ControllerBase
    {
        private readonly IHouseRepository _houseRepository;
        public HomesController(IHouseRepository houseRepository)
        {
            _houseRepository = houseRepository;
        }

        [HttpGet]
        public List<House> GetAll()
        {
            return _houseRepository.GetAll();
        }

        [HttpPost]
        public House Add([FromBody] HouseDTO house)
        {
            return _houseRepository.Add(house);
        }
    }
}
