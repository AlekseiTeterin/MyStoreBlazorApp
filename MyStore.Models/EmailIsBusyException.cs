
namespace MyStore.Models
{
    public class EmailIsBusyException : Exception
    {
        public EmailIsBusyException(string msg) : base(msg)
        {
        }
    }
}
