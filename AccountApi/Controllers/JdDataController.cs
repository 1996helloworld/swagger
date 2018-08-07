using Business;
using DataAccess;
using Entity;
using Repository;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Data;
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
        /// 公用方法
        /// </summary>
        public readonly RepositoryFactory<GoodsDetails> _GoodsDetails = new RepositoryFactory<GoodsDetails>();
        /// <summary>
        /// 获取所有商品
        /// </summary>
        /// <returns></returns>
        [System.Web.Mvc.HttpGet]
        [SwaggerOperation("GetAllMachine")]
        [Route("path/GetAllMachine")]
        public List<BaseInfo> GetAllMachine()
        {
            return repositoryfactory.Repository().FindList();
        }
        /// <summary>
        /// 查询该商品下所有机型
        /// </summary>
        /// <param name="Id">商品Id</param>
        /// <returns></returns>
        [System.Web.Mvc.HttpGet]
        [SwaggerOperation("GetAllType")]
        [Route("path/GetAllType")]
        public List<GoodsDetails> GetAllType(string Id)
        {
            string sql = "select * from GoodsDetails where BaseInfoId ='"+Id+"'";
            return _GoodsDetails.Repository().FindListBySql(sql);
        }
    }
}
