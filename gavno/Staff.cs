using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gavno
{
    internal class Staff
    {
        public int id {  get; set; }
        public string name { get; set; }
        public int position { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string salt { get; set; }
    }
}
