using System;
using System.Collections.Generic;
using System.Text;

namespace Impact
{
    public class HomePagePost
    {
        public int postID { get; set; }
        public int creatorUID { get; set; }
        public string posterName { get; set; }
        public string postTitle { get; set; }
        public string postBody { get; set; }
        public string universityImageUrl { get; set; }

        public List<HomePagePost> GetPosts()
        {
            List<HomePagePost> speakers = new List<HomePagePost>()
            {
                new HomePagePost() { postID = 1, creatorUID = 1, posterName= "Administration", postTitle = "Never Share Your Password", postBody = "This is where the contents of your post will live", universityImageUrl = "https://content.haycdn.com/mgen/options:FNM363_606_LSU.jpg?is=700,700,0xffffff" },
                new HomePagePost() { postID = 2, creatorUID = 2, posterName= "Jacob", postTitle = "New Apple Product!", postBody = "This is where the contents of your post will live", universityImageUrl = "https://content.haycdn.com/mgen/options:FNM363_606_LSU.jpg?is=700,700,0xffffff" },
                new HomePagePost() { postID = 3, creatorUID = 3, posterName= "Sarah", postTitle = "Check this out!", postBody = "This is where the contents of your post will live", universityImageUrl = "https://content.haycdn.com/mgen/options:FNM363_606_LSU.jpg?is=700,700,0xffffff" },
                new HomePagePost() { postID = 4, creatorUID = 4, posterName= "Avery", postTitle = "What a day today was", postBody = "This is where the contents of your post will live", universityImageUrl = "https://content.haycdn.com/mgen/options:FNM363_606_LSU.jpg?is=700,700,0xffffff" },
                new HomePagePost() { postID = 5, creatorUID = 5, posterName= "Angel", postTitle = "You should read this", postBody = "This is where the contents of your post will live", universityImageUrl = "https://content.haycdn.com/mgen/options:FNM363_606_LSU.jpg?is=700,700,0xffffff" },
                new HomePagePost() { postID = 6, creatorUID = 6, posterName= "Claudia", postTitle = "Calling all gear heads", postBody = "This is where the contents of your post will live", universityImageUrl = "https://content.haycdn.com/mgen/options:FNM363_606_LSU.jpg?is=700,700,0xffffff" },
                new HomePagePost() { postID = 7, creatorUID = 7, posterName= "Jimmy", postTitle = "New Video Game!", postBody = "This is where the contents of your post will live", universityImageUrl = "https://content.haycdn.com/mgen/options:FNM363_606_LSU.jpg?is=700,700,0xffffff" },
                new HomePagePost() { postID = 8, creatorUID = 8, posterName= "Ricky", postTitle = "Fantastic News", postBody = "This is where the contents of your post will live", universityImageUrl = "https://content.haycdn.com/mgen/options:FNM363_606_LSU.jpg?is=700,700,0xffffff" },
                new HomePagePost() { postID = 9, creatorUID = 9, posterName= "Alex", postTitle = "Airpods 1 prices going down?", postBody = "This is where the contents of your post will live", universityImageUrl = "https://content.haycdn.com/mgen/options:FNM363_606_LSU.jpg?is=700,700,0xffffff" },
                new HomePagePost() { postID = 10, creatorUID = 10, posterName= "Bree", postTitle = "Grades for Homework 1", postBody = "This is where the contents of your post will live", universityImageUrl = "https://content.haycdn.com/mgen/options:FNM363_606_LSU.jpg?is=700,700,0xffffff" }
            };
            return speakers;
        }
    }
}