
namespace MyStore.Domain
{
    public class EmailIsOccupiedException : Exception
    {
        public EmailIsOccupiedException(string msg) : base(msg)
        {
        }
    }
}
