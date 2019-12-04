using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Impact
{
    class MessageTemplateSelector : DataTemplateSelector
    {
        DataTemplate incomingDataTemplate;
        DataTemplate outgoingDataTemplate;

        public MessageTemplateSelector()
        {
            this.incomingDataTemplate = new DataTemplate(typeof(MessageIncomingViewCell));
            this.outgoingDataTemplate = new DataTemplate(typeof(MessageOutgoingViewCell));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var messageVm = item as Message;
            if (messageVm == null)
                return null;


            return (messageVm.User == App.User) ? incomingDataTemplate : outgoingDataTemplate;
        }

    }
}
