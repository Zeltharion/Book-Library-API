namespace API.Infrastructure
{
    public interface IServiceModel<T>
    {
        IEnumerable<T> get();
        T Upd<C>(C Id, T Enty);
        T Add(T Enty);
        T get<C>(C Id);
    }
}
