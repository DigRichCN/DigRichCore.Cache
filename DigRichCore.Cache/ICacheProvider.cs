using System;

namespace DigRichCore.Cache {
    public interface ICacheProvider {
        private static object cacheLocker = new object();//缓存锁对象

        /// <summary>
        /// 缓存过期时间
        /// </summary>
        int TimeOut { set; get; }

        /// <summary>
        /// 获得指定键的缓存值
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <returns>缓存值</returns>
        object Get(string key);
        /// <summary>
        /// 获得指定键的缓存值
        /// </summary>
        T Get<T>(string key);

        /// <summary>
        /// 从缓存中移除指定键的缓存值
        /// </summary>
        /// <param name="key">缓存键</param>
        void Remove(string key);


        /// <summary>
        /// 将指定键的对象添加到缓存中
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">缓存值</param>
        void Insert<T>(string key, T data);

        /// <summary>
        /// 将指定键的对象添加到缓存中，并指定过期时间
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">缓存值</param>
        /// <param name="timeSpan">缓存过期时间(TimeSpan)</param>
        void Insert<T>(string key, T data, TimeSpan timeSpan);



        /// <summary>
        /// 判断key是否存在
        /// </summary>
        bool Exists(string key);
    }
}
