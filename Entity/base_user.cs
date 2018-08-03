using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class base_user
    {
        /// <summary>
        /// Id
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd { get; set; }
        /// <summary>
        /// 最后登陆时间
        /// </summary>
        public string lastLogin { get; set; }
    }
}
