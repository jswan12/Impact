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
                new MessagePageConnections() { pid = 1, userName= "Angel", lastText = "'Thanks, you too!'", universityImageUrl = "https://content.haycdn.com/mgen/options:FNM363_606_LSU.jpg?is=700,700,0xffffff"},
                new MessagePageConnections() { pid = 2, userName= "Avery", lastText = "'Do you have any more references?'", universityImageUrl = "https://content.haycdn.com/mgen/options:FNM363_606_LSU.jpg?is=700,700,0xffffff"},
                new MessagePageConnections() { pid = 3, userName= "Sarah", lastText = "'Wow, thats really interesting. Thanks!'", universityImageUrl = "https://content.haycdn.com/mgen/options:FNM363_606_LSU.jpg?is=700,700,0xffffff"},
                new MessagePageConnections() { pid = 4, userName= "Claudia", lastText = "You: 'Hey, when you get a second you should check this link out https://...'", universityImageUrl = "https://content.haycdn.com/mgen/options:FNM363_606_LSU.jpg?is=700,700,0xffffff" }
            };
            return Users;
        }
    }
}