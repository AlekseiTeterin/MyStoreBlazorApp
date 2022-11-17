namespace MyStore.Models
{
    public class Product : IEntity
    {
        public Product(Guid id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
        public Product()
        {

        }
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public decimal Price { get; set; } = 100m;
    }
}