using System;
using System.Net;
using System.Net.Http;
using Microsoft.Extensions.Caching.Memory;
using Polly;
using Polly.Caching;
using Polly.Caching.Memory;
using Refit;

namespace Weather.Factories
{
    public class PolicyFactory : IPolicyFactory
    {
        public const int ServerErrorUpperValue = 600;

        // Could be moved to configuration file / firebase remote config as well
        public const int RetryCount = 2;
        public const int TimeoutSeconds = 60;
        public const int CacheTTLMinutes = 10;

        public IAsyncPolicy<T> Get<T>() where T : class
        {
            // memoryCacheProvider can be extracted into a factory and injected into here through constructor
            var memoryCache = new MemoryCache(new MemoryCacheOptions());
            var memoryCacheProvider = new MemoryCacheProvider(memoryCache);

            var defaultCachePolicy = Policy
                .CacheAsync<T>(
                    memoryCacheProvider,
                    TimeSpan.FromMinutes(CacheTTLMinutes));

            var defaultRetryPolicy = Policy<T>
                .Handle<ApiException>(IsServerError)
                .WaitAndRetryAsync(RetryCount, attempt => TimeSpan.FromSeconds(Math.Pow(2, attempt)));
            var defaultTimeoutPolicy = Policy.TimeoutAsync<T>(TimeoutSeconds, Polly.Timeout.TimeoutStrategy.Optimistic);

            return Policy.WrapAsync(defaultCachePolicy, defaultRetryPolicy, defaultTimeoutPolicy);
        }

        private Ttl GetCacheTtl(Context c, HttpResponseMessage result)
        {
            return new Ttl(
                timeSpan: result.StatusCode == HttpStatusCode.OK ?
                            TimeSpan.FromMinutes(CacheTTLMinutes) :
                            TimeSpan.Zero,
                slidingExpiration: true
            );
        }

        private bool IsServerError(ApiException ex)
        {
            return ex.StatusCode >= HttpStatusCode.InternalServerError &&
                    (int)ex.StatusCode < ServerErrorUpperValue;
        }
    }
}
