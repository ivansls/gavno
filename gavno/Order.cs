using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gavno
{
    internal class Order
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int staff {  get; set; }
        public int cost { get; set; }
        public int status { get; set; }
        public string purchased_cups { get; set; }
    }
}
