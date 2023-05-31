using System;
using System.Collections.Generic;
using System.Text;

namespace DigRichCore.Cache {
    public class CacheConfig {
        /// <summary>
        /// 可选值memory或redis，如果不为redis默认为memory
        /// </summary>
        public string Provider { get; set; }
        /// <summary>
        /// 当为redis时的连接字符串
        /// </summary>
        public string ConnectionString { get; set; }
        /// <summary>
        /// 指定数据库编号
        /// </summary>
        public int Database { get; set; } = -1;
    }
}
