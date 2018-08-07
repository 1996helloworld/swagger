using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Report
    {
        public string Title { get; set; }
        public int MaxPrice { get; set; }
        public int MinPrice { get; set; }
        public DateTime CreateTime { get; set; }
        public qushi Qushi { get; set; }
    }
    public class qushi
    {
        /// <summary>
        /// 店铺
        /// </summary>
        public string Store { get; set; }
        public int Price { get; set; }
    }
}
