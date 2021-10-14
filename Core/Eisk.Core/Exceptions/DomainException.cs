namespace Eisk.Core.Exceptions
{
    public class InvalidDataException<TEntity>: CoreException
    {
        public InvalidDataException(string message = null, string errorCode = null) : base(message, errorCode)
        {

        }
    }
}