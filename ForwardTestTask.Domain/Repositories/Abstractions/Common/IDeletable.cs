namespace ForwardTestTask.Domain.Repositories.Abstraction.Common
{
    public interface IDeletable<T> where T : class
    {
        Task<bool> DeleteAsync(T entity);
    }
}
