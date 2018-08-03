using DataAccess;
using DataAccess.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    /// <summary>
    /// 操作数据库工厂
    /// </summary>
    public class DataFactory
    {
        /// <summary>
        /// 当前数据库类型
        /// </summary>
        private static string DbType = "SqlServer";

        /// <summary>
        /// 获取指定的数据库连接
        /// </summary>
        /// <param name="connString"></param>
        /// <returns></returns>
        public static IDatabase Database(string connString)
        {
            return new Database(connString);
        }
        /// <summary>
        /// 获取指定的数据库连接
        /// </summary>
        /// <returns></returns>
        public static IDatabase Database()
        {
            switch (DbType)
            {
                case "SqlServer":
                    return Database("HighnetFramework_SqlServer");
                case "MySql":
                    return Database("HighnetFramework_MySql");
                case "Oracle":
                    return Database("HighnetFramework_Oracle");
                default:
                    return null;
            }
        }
    }
}
