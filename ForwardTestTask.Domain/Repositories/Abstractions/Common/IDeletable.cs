namespace ForwardTestTask.Domain.Repositories.Abstraction.Common
{
    public interface IDeletable<T>
    {
        Task<bool> DeleteAsync(T entity);
    }
}
