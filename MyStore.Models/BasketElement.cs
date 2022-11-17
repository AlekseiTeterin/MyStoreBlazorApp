
namespace MyStore.Models
{
    public class BasketElement
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int ItemNumbers { get; set; }
    }
}
