using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// 京东商品
    /// </summary>
    public class BaseInfo
    {
        //[Id], [Title], [Image], [Store], [Comment], [Url], [CreateDate]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Store { get; set; }
        public string Comment { get; set; }
        public string Url { get; set; }
        public string CreateDate { get; set; }
    }
}
