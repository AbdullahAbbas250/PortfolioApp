namespace Core.Interfaces
{
    public interface IUnitOfWork<Type> where Type:class
    {
        IGenericRepository<Type> Entity { get; }
        void Save();
    }
}
