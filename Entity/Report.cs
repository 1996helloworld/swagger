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
        public double MaxPrice { get; set; }
        public double MinPrice { get; set; }
        public DateTime CreateTime { get; set; }
        public List<qushi> Qushi { get; set; }
    }
    public class qushi
    {
        /// <summary>
        /// 店铺
        /// </summary>
        public string Store { get; set; }
        public string Price { get; set; }
    }
}
