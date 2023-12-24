namespace API.Infrastructure
{
    public interface IUpdate<E>
    {
        E Update(E? entity);
    }
}
