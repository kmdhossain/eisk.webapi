namespace Eisk.Core.Exceptions
{
    public class InvalidOperationException<TEntity>: CoreException
    {
        public InvalidOperationException(string message = null, string errorCode = null) : base(message, errorCode)
        {

        }
    }
}