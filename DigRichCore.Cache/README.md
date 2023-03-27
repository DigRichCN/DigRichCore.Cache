引用包 DigRichCore.Cache
配置文件：
"CacheConfig":{
	"Provider":"redis",
	"ConnectionString":"redis连接字符串"
}
使用方法：
services.AddRedisOrMemoryCaching(configure.GetSection<CacheConfig>("CacheConfig"))