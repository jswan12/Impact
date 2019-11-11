using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Impact
{
    public class User
    {
        public int uid { get; set; }
        public string email_address { get; set; }
        public int credentials_id { get; set; }
        public string name { get; set; }
        public DateTime birthday { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string gender { get; set; }
        public string major { get; set; }
    }
}
