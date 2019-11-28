using System;
using System.Collections.Generic;
using System.Text;

namespace Impact
{
    public class MatchesPageMentorViewModel
    {
        public List<MatchesPageMentor> MentorModels { get; set; }

        public MatchesPageMentorViewModel()
        {
            MentorModels = new MatchesPageMentor().GetMentors();
        }
    }
}
