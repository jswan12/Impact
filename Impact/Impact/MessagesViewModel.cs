using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Impact;
using PropertyChanged;
using Xamarin.Forms;

namespace Impact
{
    public class MessagesViewModel : INotifyPropertyChanged
    {
        public bool ShowScrollTap { get; set; } = false;
        public bool LastMessageVisible { get; set; } = true;
        public int PendingMessageCount { get; set; } = 0;
        public bool PendingMessageCountVisible { get { return PendingMessageCount > 0; } }

        public Queue<Message> DelayedMessages { get; set; } = new Queue<Message>();
        public ObservableCollection<Message> Messages { get; set; } = new ObservableCollection<Message>();
        public string TextToSend { get; set; }
        public ICommand OnSendCommand { get; set; }
        public ICommand MessageAppearingCommand { get; set; }
        public ICommand MessageDisappearingCommand { get; set; }

        public MessagesViewModel()
        {
            //Fake previous hardcoded conversation
            Messages.Insert(0, new Message() { Text = "Test", User = App.User });
            Messages.Insert(0, new Message() { Text = "Test!" });
            Messages.Insert(0, new Message() { Text = "Hey, what's up?", User = App.User });
            Messages.Insert(0, new Message() { Text = "Nothing much, just working on the messaging feature" });
            Messages.Insert(0, new Message() { Text = "Hopefully it will be done in time" });
            Messages.Insert(0, new Message() { Text = "I'm sure you'll get it doen", User = App.User });
            Messages.Insert(0, new Message() { Text = "*done", User = App.User });
            Messages.Insert(0, new Message() { Text = "Yeah lol I hope so.." });
            Messages.Insert(0, new Message() { Text = "You ready for the demo on thursday?", User = App.User });
            Messages.Insert(0, new Message() { Text = "Yeah" });
            Messages.Insert(0, new Message() { Text = "I'm a little nervous but hopefully we'll do well" });
            Messages.Insert(0, new Message() { Text = "Yeah, same. I think we'll do great!", User = App.User });
            Messages.Insert(0, new Message() { Text = "Yeah, we'll see" });
            Messages.Insert(0, new Message() { Text = "Alright, see you then. Good luck!", User = App.User });
            Messages.Insert(0, new Message() { Text = "Thanks, you too!" });

            //Perhaps scroll through dialogue to let audience read

            MessageAppearingCommand = new Command<Message>(OnMessageAppearing);
            MessageDisappearingCommand = new Command<Message>(OnMessageDisappearing);

            //Keeps track of sent messages
            int counter = 0;

            //Begin scripted hardcoded dialogue
            OnSendCommand = new Command(() =>
            {
                if (!string.IsNullOrEmpty(TextToSend))
                {
                    counter++;
                    Messages.Insert(0, new Message() { Text = TextToSend, User = App.User });
                    TextToSend = string.Empty;

                    //First message sent -> "Hey"
                    if (counter == 1)
                    {
                        //First message response -> "Hey"
                        Device.StartTimer(TimeSpan.FromSeconds(5), () =>
                        {
                            if (LastMessageVisible)
                            {
                                Messages.Insert(0, new Message() { Text = "Hey" });
                            }
                            else
                            {
                                DelayedMessages.Enqueue(new Message() { Text = "Hey" });
                                PendingMessageCount++;
                            }
                            return false;
                        });
                    }

                    //Second message sent -> "How are you?"
                    if (counter == 2)
                    {
                        //Second message response-> "Good, you?"
                        Device.StartTimer(TimeSpan.FromSeconds(7), () =>
                        {
                            if (LastMessageVisible)
                            {
                                Messages.Insert(0, new Message() { Text = "Good, you?" });
                            }
                            else
                            {
                                DelayedMessages.Enqueue(new Message() { Text = "Good, you?" });
                                PendingMessageCount++;
                            }
                            return false;
                        });
                    }

                    /* Third message sent -> "Good"                                      *
                     * Perhaps talk to the audience about the use cases of the messaging *
                     * feature and how it will assist mentors and students to openly     *
                     * communicate.                                                      */


                    //Fourth message sent -> "Alright, I gotta finish presenting. See you Later!"
                    if (counter == 4)
                    {
                        //Third message response -> "Alright, later!"
                        Device.StartTimer(TimeSpan.FromSeconds(7), () =>
                        {
                            if (LastMessageVisible)
                            {
                                Messages.Insert(0, new Message() { Text = "Alright, later!" });
                            }
                            else
                            {
                                DelayedMessages.Enqueue(new Message() { Text = "Alright, later!" });
                                PendingMessageCount++;
                            }
                            return false;
                        });
                    }
                }
            });
            //End scripted hardcoded dialogue. 
                                                                                          
            /* I was too lazy to make a function to be able to easily create and change       *
             * the scripted dialogue, so anything we want to add or change, just manupulate   *
             * the code above. Hopefully its easy to recognize how to add new ones. We should *
             * consider deploying one dialogue varient for the presenter and one for the      *
             * "receiver" to make it more convincing that we are messaging cross platform     *
             * in real time.                                                                  */

            void OnMessageAppearing(Message message)
            {
                var idx = Messages.IndexOf(message);
                if (idx <= 6)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        while (DelayedMessages.Count > 0)
                        {
                            Messages.Insert(0, DelayedMessages.Dequeue());
                        }
                        ShowScrollTap = false;
                        LastMessageVisible = true;
                        PendingMessageCount = 0;
                    });
                }
            }

            void OnMessageDisappearing(Message message)
            {
                var idx = Messages.IndexOf(message);
                if (idx >= 6)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        ShowScrollTap = true;
                        LastMessageVisible = false;
                    });

                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}