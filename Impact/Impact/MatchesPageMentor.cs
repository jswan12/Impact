using System;
using System.Collections.Generic;
using System.Text;

namespace Impact
{
    public class MatchesPageMentor
    {
            public string User_Name { get; set; }
            public string Location { get; set; }
            public string Details { get; set; }
            public string ImageUrl { get; set; }

            public List<MatchesPageMentor> GetMentors()
            {
                List<MatchesPageMentor> MentorModels = new List<MatchesPageMentor>()
                {
                    new MatchesPageMentor() { User_Name = "Abby Richard", Location = "Hampton", Details="So many details", ImageUrl="https://content.haycdn.com/mgen/options:FNM363_606_LSU.jpg?is=700,700,0xffffff"},
                    new MatchesPageMentor() { User_Name = "Bobby Snow", Location = "Georgia", Details="Not so many details", ImageUrl="https://content.haycdn.com/mgen/options:FNM363_606_LSU.jpg?is=700,700,0xffffff"},
                    new MatchesPageMentor() { User_Name = "Cathy Noble", Location = "New York", Details="Yikes", ImageUrl="https://content.haycdn.com/mgen/options:FNM363_606_LSU.jpg?is=700,700,0xffffff"},
                    new MatchesPageMentor() { User_Name = "Darrious Blanchard", Location = "Destrehan", Details="Hello this is my bio", ImageUrl="https://content.haycdn.com/mgen/options:FNM363_606_LSU.jpg?is=700,700,0xffffff"},
                    new MatchesPageMentor() { User_Name = "Frank Gore", Location = "Buffalo", Details="What are you looking at", ImageUrl="https://content.haycdn.com/mgen/options:FNM363_606_LSU.jpg?is=700,700,0xffffff"},
                    new MatchesPageMentor() { User_Name = "Heather Wise", Location = "New Mexico", Details="Yeah im cool", ImageUrl="https://content.haycdn.com/mgen/options:FNM363_606_LSU.jpg?is=700,700,0xffffff"},
                    new MatchesPageMentor() { User_Name = "John Mappple", Location = "Laplace", Details="Do your work bro", ImageUrl="https://content.haycdn.com/mgen/options:FNM363_606_LSU.jpg?is=700,700,0xffffff"},
                    new MatchesPageMentor() { User_Name = "Kayla Lott", Location = "Texas", Details="I can't help you study, sorry", ImageUrl="https://content.haycdn.com/mgen/options:FNM363_606_LSU.jpg?is=700,700,0xffffff"},
                    new MatchesPageMentor() { User_Name = "Pablo Sinco", Location = "Canada", Details="Catch me outside", ImageUrl="https://content.haycdn.com/mgen/options:FNM363_606_LSU.jpg?is=700,700,0xffffff"},
                    new MatchesPageMentor() { User_Name = "Samantha Breaux", Location = "Vermont", Details="Rant to me!!", ImageUrl="https://content.haycdn.com/mgen/options:FNM363_606_LSU.jpg?is=700,700,0xffffff"}


                };
                return MentorModels;
            }
    }
}