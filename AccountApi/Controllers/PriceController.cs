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
        /// 公用方法
        /// </summary>
        public readonly RepositoryFactory<qushi> _qushi = new RepositoryFactory<qushi>();
        /// <summary>
        /// 获取一条商品的最高和最高价
        /// </summary>
        /// <param name="Id">商品Id</param>
        /// <returns></returns>
        [System.Web.Mvc.HttpGet]
        [SwaggerOperation("GetPrice")]
        [Route("path/GetPrice")]
        public Report GetPrice(string Id)
        {
            try
            {
                Report m = new Report();
                string desc = "select (select Title from BaseInfo where Id=(select BaseInfoId from GoodsDetails where Url=DayReport.GoodsDetailId))+(select Name from GoodsDetails where Url=DayReport.GoodsDetailId)as'Title',Price,CreateTime from DayReport where GoodsDetailId='26328972387'order by Price desc";
                string asc = "select (select Title from BaseInfo where Id=(select BaseInfoId from GoodsDetails where Url=DayReport.GoodsDetailId))+(select Name from GoodsDetails where Url=DayReport.GoodsDetailId)as'Title',Price,CreateTime from DayReport where GoodsDetailId='26328972387'order by Price asc";
                var dtdesc = repositoryfactory.Repository().FindTableBySql(desc);
                var dtasc = repositoryfactory.Repository().FindTableBySql(asc);
                m.MaxPrice = Convert.ToDouble(dtdesc.Rows[0]["price"]);
                m.MinPrice = Convert.ToDouble(dtasc.Rows[0]["price"]);
                m.Title = dtdesc.Rows[0]["title"].ToString();
                m.CreateTime = Convert.ToDateTime(dtdesc.Rows[0]["createtime"]);
                List<qushi> q = _qushi.Repository().FindListBySql(@"select top 10 s.Store,s.Price from 
                                                            (select *,row_number() over (partition by Store order by Price) as group_idx  from
                                                            (select top 100 (select Store from BaseInfo where Id=(select BaseInfoId from GoodsDetails where Url=DayReport.GoodsDetailId))as'Store',* from DayReport where GoodsDetailId in(select Url from GoodsDetails where Type=(select Type from GoodsDetails where Url='" + Id+"')) order by Price asc) T)s where s.group_idx =1 order by s.Price asc");
                m.Qushi = q;
                return m;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
