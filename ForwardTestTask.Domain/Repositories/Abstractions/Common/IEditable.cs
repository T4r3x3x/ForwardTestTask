namespace ForwardTestTask.Domain.Repositories.Abstraction.Common
{
    public interface IEditable<T> where T : class
    {
        Task<bool> EditAsync(T entity);
    }
}
