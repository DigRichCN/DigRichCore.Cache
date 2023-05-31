引用包 DigRichCore.Cache
配置文件：
"CacheConfig": {
    "Provider": "redis", //memory
    "ConnectionString": "127.0.0.1:6379,allowadmin=false,ConnectRetry=5,Password=111111",
    "Database": 1
  },
使用方法：
services.AddRedisOrMemoryCaching(configure.GetValue<CacheConfig>("CacheConfig"))