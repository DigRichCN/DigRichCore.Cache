using DigRich.Common.Extension;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigRichCore.Cache {
    public static class ServiceCollectionExtensions {
        public static void AddRedisOrMemoryCaching(this IServiceCollection services, IOptions<CacheConfig> cfgOptions) {
            var cfg = cfgOptions.Value;
            services.AddSingleton(cfg);
            if (cfg.Provider.ToEString().ToLower() == "redis") {
                services.AddSingleton<ICacheProvider, RedisProvider>();
            }
            else {
                services.AddSingleton<ICacheProvider, MemoryProvider>();
            }
        }
    }
}
