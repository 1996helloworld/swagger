using Business;
using DataAccess;
using Entity;
using Repository;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace AccountApi.Controllers
{
    /// <summary>
    /// 账户
    /// </summary>
    public class AccountController : ApiController
    {
        /// <summary>
        /// 公用方法
        /// </summary>
        public readonly RepositoryFactory<AllAccount> repositoryfactory = new RepositoryFactory<AllAccount>();
        /// <summary>
        /// 逻辑类
        /// </summary>
        public readonly CheckUserbll _mybll = new CheckUserbll();
        /// <summary>
        /// 获取所以账户
        /// </summary>
        /// <param name="Account">用户名</param>
        /// <param name="Pwd">密码</param>
        /// <returns></returns>
        [System.Web.Mvc.HttpGet]
        [SwaggerOperation("GetAll")]
        [Route("path/GetAll")]
        public IEnumerable<AllAccount> GetAll(string Account, string Pwd)
        {
            return repositoryfactory.Repository().FindList().Where(t=>t.UserId==_mybll.CheckUser(Account,Pwd).id);
        }
        /// <summary>
        /// 获取单个账户信息
        /// </summary>
        /// <param name="Portal">门户</param>
        /// <param name="Account">账户</param>
        /// <param name="Pwd">密码</param>
        /// <returns></returns>
        [System.Web.Mvc.HttpGet]
        [SwaggerOperation("GetSingle")]
        [Route("path/GetSingle")]
        public AllAccount GetSingle(string Portal, string Account, string Pwd)
        {
            return GetAll(Account, Pwd).Single(s => s.Portal.Contains(Portal));//注释
        }
    }
}
