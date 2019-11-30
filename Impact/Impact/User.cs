using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Impact
{
    public class User
    {
        public int uid { get; set; }
        public string imageUrl { get; set; }
        public string email_address { get; set; }
        public int credentials_id { get; set; }
        public string name { get; set; }
        public DateTime birthday { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string gender { get; set; }
        public string major { get; set; }
        public int user_type { get; set; }
        public string interest1 { get; set; }
        public string interest2 { get; set; }
        public string interest3 { get; set; }
        public string hobby1 { get; set; }
        public string hobby2 { get; set; }
        public string hobby3 { get; set; }
    }
}
