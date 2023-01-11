namespace APIwithFrontNT
{
    public interface IHouseRepository
    {
        List<House> GetAll();
        House Add(HouseDTO house);       
    }
}
