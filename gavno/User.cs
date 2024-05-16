using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gavno
{
    internal class User
    {
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string salt { get; set; }
        public string name { get; set; }
        public int all_purchase_sum { get; set; }
        public int discount { get; set; }
        
    }
}
