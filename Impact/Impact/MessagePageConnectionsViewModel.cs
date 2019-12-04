using System;
using System.Collections.Generic;
using System.Text;

namespace Impact
{
    public class MessagePageConnectionsViewModel
    {
        public List<MessagePageConnections> Messages { get; set; }

        public MessagePageConnectionsViewModel()
        {
            Messages = new MessagePageConnections().GetUsers();
        }
    }
}