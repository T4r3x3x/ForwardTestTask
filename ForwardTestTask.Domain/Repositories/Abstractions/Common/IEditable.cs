namespace ForwardTestTask.Domain.Repositories.Abstraction.Common
{
    public interface IEditable<T> where T : class
    {
        Task<bool> Edit(T entity);
    }
}
