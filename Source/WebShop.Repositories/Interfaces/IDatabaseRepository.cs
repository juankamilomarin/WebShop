namespace WebShop.DataAccess.Interfaces
{
    /// <summary>
    /// The interface definition for a database repository.
    /// </summary>
    public interface IDatabaseRepository<T> : IGenericRepository<T> where T : class
    {
    }
}
