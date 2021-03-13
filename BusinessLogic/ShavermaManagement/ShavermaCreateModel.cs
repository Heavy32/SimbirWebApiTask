namespace BusinessLogic.ShavermaManagement
{
    public class ShavermaCreateModel
    {
        public ShavermaCreateModel(string name, float price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; }
        public float Price { get; }
    }
}
