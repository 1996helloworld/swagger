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
    public class PriceController : ApiController
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
        /// 获取一条商品的最高和最高价
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="test"></param>
        /// <returns></returns>
        [System.Web.Mvc.HttpGet]
        [SwaggerOperation("GetPrice")]
        [Route("path/GetPrice")]
        public Report GetPrice(string Id, string test)
        {
            Report m = new Report();
            string sql = "select (select Title from BaseInfo where Id=(select BaseInfoId from GoodsDetails where Url=DayReport.GoodsDetailId))+(select Name from GoodsDetails where Url=DayReport.GoodsDetailId)as'Title',Price,CreateTime from DayReport where GoodsDetailId='" + Id + "'";
            DataTable dt = repositoryfactory.Repository().FindTableBySql(sql);
            var d1 = dt.Compute("Max(price)", null);
            var d2 = dt.Compute("Min(price)", null);
            m.MaxPrice =Convert.ToInt32(d1);
            m.MinPrice = Convert.ToInt32(d2);
            return null;
        }
    }
}
