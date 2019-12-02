using System;
using System.Collections.Generic;
using System.Text;

namespace Impact
{
    public class ConnectionsPageUsersViewModel
    {
        public List<ConnectionsPageUser> UserModels { get; set; }

        public ConnectionsPageUsersViewModel()
        {
            UserModels = new ConnectionsPageUser().GetUsers();
        }
    }
}
