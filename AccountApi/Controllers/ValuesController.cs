using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Business;
using Repository;

namespace AccountApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class ValuesController : ApiController
    {
        public readonly RepositoryFactory<AllAccount> repositoryfactory = new RepositoryFactory<AllAccount>();
        private CheckUserbll _bll = new CheckUserbll();
        // GET api/values
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<AllAccount> Get()
        {
            return repositoryfactory.Repository().FindList();
        }

        // GET api/values/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AllAccount Get(string id)
        {
            return repositoryfactory.Repository().FindEntityBySql("SELECT id,Account,Pwd,Portal,Type,UserId FROM AllAccount where Portal='"+ id + "'");
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
