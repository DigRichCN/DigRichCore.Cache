using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;

namespace DigRichCore.Cache {
    public class MemoryProvider : ICacheProvider {
        static object cacheLocker = new object();
        private IMemoryCache cache;

        public MemoryProvider(IMemoryCache memoryCache) {

            cache = memoryCache;
        }

        /// <summary>
        /// 获得指定键的缓存值
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <returns>缓存值</returns>
        public object Get(string key) {
            return cache.Get(key);
        }

        public T Get<T>(string key) {
            T result = (T)cache.Get(key);
            return result;
        }

        /// <summary>
        /// 从缓存中移除指定键的缓存值
        /// </summary>
        /// <param name="key">缓存键</param>
        public void Remove(string key) {
            cache.Remove(key);
        }

        public bool Exists(string key) {
            if (cache.Get(key) != null)
                return true;
            else
                return false;
        }

        public void Insert<T>(string key, T value) {
            lock (cacheLocker) {
                if (cache.Get(key) != null)
                    cache.Remove(key);
                cache.Set(key, value);
            }
        }

        public void Insert<T>(string key, T value, TimeSpan timeSpan) {
            lock (cacheLocker) {
                if (cache.Get(key) != null)
                    cache.Remove(key);
                cache.Set(key, value, new MemoryCacheEntryOptions().SetSlidingExpiration(timeSpan));
            }
        }

        const int DEFAULT_TMEOUT = 600;//默认超时时间（单位秒）

        private int _timeout = DEFAULT_TMEOUT;

        /// <summary>
        /// 缓存过期时间
        /// </summary>
        /// <value></value>
        public int TimeOut {
            get {
                return _timeout;
            }
            set {
                _timeout = value > 0 ? value : DEFAULT_TMEOUT;
            }
        }
    }
}
