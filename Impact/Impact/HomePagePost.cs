using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Impact
{
    public class HomePagePost
    {
        public int pid { get; set; }
        public int creator_uid { get; set; }
        public string posterName { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public string imageUrl { get; set; }
    }
}