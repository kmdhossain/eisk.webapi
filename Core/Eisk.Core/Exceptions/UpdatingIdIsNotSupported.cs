namespace Eisk.Core.Exceptions
{
    public class UpdatingIdIsNotSupported<TEntity>: InvalidDataException<TEntity>

    {
        public UpdatingIdIsNotSupported(object paramValue, string paramName = "id") : base(
            $"Updating {typeof(TEntity).Name} field {paramName} is not supported. Provided value: {paramValue}.", "APP-DATA-ERROR-004")
        {
            
        }
    }
}