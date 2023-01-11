using APIwithFrontNT.DB;

namespace APIwithFrontNT
{
    public class HouseRepository : IHouseRepository
    {
        private readonly AppDbContext _context;
        public HouseRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<House> GetAll()
        {
            return _context.Houses.ToList();
        }
        public House Add(HouseDTO house)
        {
            var newHouse = new House
            {
                Price = house.Price,
                City = house.City,
                Description = house.Description,
                Image = house.Image
            };
            _context.Add(newHouse);
            _context.SaveChanges();
            return newHouse;
        }       
    }
}
