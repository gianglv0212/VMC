using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VMC.EO
{
    [Serializable()]
    public class LoginEO
    {
        public String fullname { get; set; }
        public String roles { get; set; }
        public Int32 uid { get; set; }
        public String avatar { get; set; }

        public String uname { get; set; }
    }
}