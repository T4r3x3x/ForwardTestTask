namespace ForwardTestTask.Domain.Repositories.Abstraction.Common
{
    public interface IReadable<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
    }
}
