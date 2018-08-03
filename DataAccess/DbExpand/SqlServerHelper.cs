using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DbExpand
{
    /// <summary>
    /// 扩展方法
    /// </summary>
    public class SqlServerHelper
    {
        #region 数据分页
        /// <summary>
        /// 摘要:
        ///     数据分页
        /// 参数：
        ///     sql：传入要执行sql语句
        ///     param：参数化
        ///     orderField：排序字段
        ///     orderType：排序类型
        ///     pageIndex：当前页
        ///     pageSize：页大小
        ///     count：返回查询条数
        /// </summary>
        public static DataTable GetPageTable(string sql, DbParameter[] param, string orderField, string orderType, int pageIndex, int pageSize, ref int count)
        {
            StringBuilder strSql = new StringBuilder();
            if (pageIndex == 0)
            {
                pageIndex = 1;
            }
            int num = (pageIndex - 1) * pageSize;
            int num1 = (pageIndex) * pageSize;
            string OrderBy = "";
            if (!string.IsNullOrEmpty(orderField))
                OrderBy = "Order By " + orderField + " " + orderType + "";
            else
                OrderBy = "order by (select 0)";
            strSql.Append("Select * From (Select ROW_NUMBER() Over (" + OrderBy + ")");
            strSql.Append(" As rowNum, * From (" + sql + ") As T ) As N Where rowNum > " + num + " And rowNum <= " + num1 + "");
            count = Convert.ToInt32(DbHelper.ExecuteScalar(CommandType.Text, "Select Count(1) From (" + sql + ") As t", param));
            IDataReader dr = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString(), param);
            return DatabaseReader.ReaderToDataTable(dr);
        }
        /// <summary>
        /// 摘要:
        ///     数据分页
        /// 参数：
        ///     sql：传入要执行sql语句
        ///     orderField：排序字段
        ///     orderType：排序类型
        ///     pageIndex：当前页
        ///     pageSize：页大小
        ///     count：返回查询条数
        /// </summary>
        public static DataTable GetPageTable(string sql, string orderField, string orderType, int pageIndex, int pageSize, ref int count)
        {
            return GetPageTable(sql, null, orderField, orderType, pageIndex, pageSize, ref count);
        }
        /// <summary>
        /// 摘要:
        ///     数据分页
        /// 参数：
        ///     sql：传入要执行sql语句
        ///     param：参数化
        ///     orderField：排序字段
        ///     orderType：排序类型
        ///     pageIndex：当前页
        ///     pageSize：页大小
        ///     count：返回查询条数
        /// </summary>
        public static List<T> GetPageList<T>(string sql, DbParameter[] param, string orderField, string orderType, int pageIndex, int pageSize, ref int count)
        {
            count = Convert.ToInt32(DbHelper.ExecuteScalar(CommandType.Text, "Select Count(1) From (" + sql + ") As t", param));

            StringBuilder strSql = new StringBuilder();

            if (pageIndex == 0)
            {
                pageIndex = 1;
            }
            int num = (pageIndex - 1) * pageSize;
            int num1 = (pageIndex) * pageSize;

            string orderBy = "";
            if (!string.IsNullOrEmpty(orderField))
            {
                orderBy = "Order By " + orderField + " " + orderType + "";
            }
            else
            {
                orderBy = "Order By (select 0)";
            }

            strSql.AppendFormat("Select * From (Select ROW_NUMBER() Over ({0})  As rowNum, * From ({1}) As T ) As N Where rowNum > {2} And rowNum <= {3}", orderBy, sql, num, num1);

            IDataReader dr = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString(), param);

            return DatabaseReader.ReaderToList<T>(dr);
        }
        /// <summary>
        /// 摘要:
        ///     数据分页
        /// 参数：
        ///     sql：传入要执行sql语句
        ///     orderField：排序字段
        ///     orderType：排序类型
        ///     pageIndex：当前页
        ///     pageSize：页大小
        ///     count：返回查询条数
        /// </summary>
        public static List<T> GetPageList<T>(string sql, string orderField, string orderType, int pageIndex, int pageSize, ref int count)
        {
            return GetPageList<T>(sql, null, orderField, orderType, pageIndex, pageSize, ref count);
        }
        #endregion
    }
}
