namespace WebShop.DataAccess.Interfaces
{
    /// <summary>
    /// The interface definition for a memory repository.
    /// </summary>
    public interface IMemoryRepository<T>: IGenericRepository<T> where T : class
    {
    }
}
