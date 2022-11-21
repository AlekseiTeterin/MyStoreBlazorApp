
namespace MyStore.Domain
{
    public class EmailIsBusyException : Exception
    {
        public EmailIsBusyException(string msg) : base(msg)
        {
        }
    }
}
