using DataAccess;
using Entity;
using Repository;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Business
{
    public class CheckUserbll : RepositoryFactory<base_user>
    {
        public readonly RepositoryFactory<base_user> base_user = new RepositoryFactory<base_user>();
        /// <summary>
        /// 检查账户是否有效
        /// </summary>
        /// <param name="Account"></param>
        /// <param name="Pwd"></param>
        /// <returns></returns>
        public base_user CheckUser(string Account, string Pwd)
        {
            StringBuilder sb = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            sb.Append("select * from base_user where 1=1 ");
            if (!string.IsNullOrEmpty(Account))
            {
                sb.Append(" and Account=@Account");
                parameter.Add(DbFactory.CreateDbParameter("@Account", Account.Trim()));
            }
            if (!string.IsNullOrEmpty(Pwd))
            {
                sb.Append(" and Pwd=@Pwd");
                parameter.Add(DbFactory.CreateDbParameter("@Pwd", Pwd.Trim()));
            }
            return base_user.Repository().FindEntityBySql(sb.ToString(), parameter.ToArray());
        }
    }
}
