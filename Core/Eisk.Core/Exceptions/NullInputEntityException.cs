namespace Eisk.Core.Exceptions
{
    public class NullInputEntityException <TEntity>: InvalidOperationException<TEntity>
    {
        public NullInputEntityException() : base("Input object to be created or updated is null.", "APP-DATA-ERROR-003")
        {
            
        }
    }
}