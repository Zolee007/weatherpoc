using Polly;

namespace Weather.Factories
{
    public interface IPolicyFactory
    {
        IAsyncPolicy<T> Get<T>() where T : class;
    }
}
