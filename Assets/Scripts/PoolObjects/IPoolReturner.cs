public interface IPoolReturner<T>
{
    void Return(T poolObject);
}