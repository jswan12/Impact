using System;
using System.Collections.Generic;
using System.Text;

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

        public List<HomePagePost> GetPosts()
        {
            List<HomePagePost> speakers = new List<HomePagePost>()
            {
                new HomePagePost() { pid = 1, creator_uid = 1, posterName= "Administration", title = "Never Share Your Password", body = "This is where the contents of your post will live", imageUrl = "https://content.haycdn.com/mgen/options:FNM363_606_LSU.jpg?is=700,700,0xffffff" },
                new HomePagePost() { pid = 2, creator_uid = 2, posterName= "Jacob", title = "New Apple Product!", body = "This is where the contents of your post will live", imageUrl = "https://content.haycdn.com/mgen/options:FNM363_606_LSU.jpg?is=700,700,0xffffff" },
                new HomePagePost() { pid = 3, creator_uid = 3, posterName= "Sarah", title = "Check this out!", body = "This is where the contents of your post will live", imageUrl = "https://content.haycdn.com/mgen/options:FNM363_606_LSU.jpg?is=700,700,0xffffff" },
                new HomePagePost() { pid = 4, creator_uid = 4, posterName= "Avery", title = "What a day today was", body = "This is where the contents of your post will live", imageUrl = "https://content.haycdn.com/mgen/options:FNM363_606_LSU.jpg?is=700,700,0xffffff" },
                new HomePagePost() { pid = 5, creator_uid = 5, posterName= "Angel", title = "You should read this", body = "This is where the contents of your post will live", imageUrl = "https://content.haycdn.com/mgen/options:FNM363_606_LSU.jpg?is=700,700,0xffffff" },
                new HomePagePost() { pid = 6, creator_uid = 6, posterName= "Claudia", title = "Calling all gear heads", body = "This is where the contents of your post will live", imageUrl = "https://content.haycdn.com/mgen/options:FNM363_606_LSU.jpg?is=700,700,0xffffff" },
                new HomePagePost() { pid = 7, creator_uid = 7, posterName= "Jimmy", title = "New Video Game!", body = "This is where the contents of your post will live", imageUrl = "https://content.haycdn.com/mgen/options:FNM363_606_LSU.jpg?is=700,700,0xffffff" },
                new HomePagePost() { pid = 8, creator_uid = 8, posterName= "Ricky", title = "Fantastic News", body = "This is where the contents of your post will live", imageUrl = "https://content.haycdn.com/mgen/options:FNM363_606_LSU.jpg?is=700,700,0xffffff" },
                new HomePagePost() { pid = 9, creator_uid = 9, posterName= "Alex", title = "Airpods 1 prices going down?", body = "This is where the contents of your post will live", imageUrl = "https://content.haycdn.com/mgen/options:FNM363_606_LSU.jpg?is=700,700,0xffffff" },
                new HomePagePost() { pid = 10, creator_uid = 10, posterName= "Bree", title = "Grades for Homework 1", body = "This is where the contents of your post will live", imageUrl = "https://content.haycdn.com/mgen/options:FNM363_606_LSU.jpg?is=700,700,0xffffff" }
            };
            return speakers;
        }
    }
}