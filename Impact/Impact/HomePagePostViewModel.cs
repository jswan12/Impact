using System;
using System.Collections.Generic;
using System.Text;

namespace Impact
{
    public class HomePagePostViewModel
    {
        public List<HomePagePost> HomePosts { get; set; }

        public HomePagePostViewModel()
        {
            HomePosts = new HomePagePost().GetPosts();
        }
    }
}
