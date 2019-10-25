using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Impact
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
