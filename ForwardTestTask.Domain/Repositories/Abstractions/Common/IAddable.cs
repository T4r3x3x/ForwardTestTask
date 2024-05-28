namespace ForwardTestTask.Domain.Repositories.Abstraction.Common
{
    public interface IAddable<T> where T : class
    {
        Task<bool> AddAsync(T entity);
    }
}