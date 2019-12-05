using System;
using System.Collections.Generic;
using System.Text;

namespace Impact
{
    public class MessagePageConnections
    {
        public int pid { get; set; }
        public string userName { get; set; }
        public string lastText { get; set; }
        public string universityImageUrl { get; set; }

        public List<MessagePageConnections> GetUsers()
        {
            List<MessagePageConnections> Users = new List<MessagePageConnections>()
            {
                new MessagePageConnections() { pid = 1, userName= "Anas Mahmoud", lastText = "* Start a new converstaion *", universityImageUrl = "https://www.lsu.edu/eng/cse/people/faculty/photos/anas.mahmoud.jpg"},
                new MessagePageConnections() { pid = 2, userName= "Nathan Brener", lastText = "'Thanks, you too!'", universityImageUrl = "https://www.lsu.edu/eng/cse/people/faculty/photos/nathan.brener.jpg"},
                new MessagePageConnections() { pid = 3, userName= "Kisung Lee", lastText = "'Wow, thats really interesting. Thanks!'", universityImageUrl = "https://www.lsu.edu/eng/cse/people/faculty/photos/kisung.lee.jpg"},
                new MessagePageConnections() { pid = 4, userName= "Mingxuan Sun", lastText = "You: 'Hey, when you get a second you should check this link out https://...'", universityImageUrl = "https://www.lsu.edu/eng/cse/people/faculty/photos/mingxuan.sun.jpg" }
            };
            return Users;
        }
    }
}