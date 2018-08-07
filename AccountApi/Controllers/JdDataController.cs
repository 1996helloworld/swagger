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
    /// 
    /// </summary>
    public class JdDataController : ApiController
    {
        /// <summary>
        /// 公用方法
        /// </summary>
        public readonly RepositoryFactory<BaseInfo> repositoryfactory = new RepositoryFactory<BaseInfo>();
        /// <summary>
        /// 获取所有商品
        /// </summary>
        /// <returns></returns>
        [System.Web.Mvc.HttpGet]
        public List<BaseInfo> GetAll()
        {
            return repositoryfactory.Repository().FindList();
        }
    }
}
