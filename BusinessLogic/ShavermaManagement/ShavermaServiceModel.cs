using Data;

namespace BusinessLogic.ShavermaManagement
{
    public class ShavermaServiceModel : IUniqueModel
    {
        public ShavermaServiceModel(int id, string name, float price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public int Id { get; }
        public string Name { get; }
        public float Price { get; }
    }
}
