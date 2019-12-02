using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Impact
{
    public partial class MainGroup : ContentPage
    {
        public MainGroup()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, true);

            Frame cardFrame = new Frame
            {
                BorderColor = Color.Gray,
                CornerRadius = 5,
                Padding = 8,
                Content = new StackLayout
                {
                    Children =
        {
            new Label
            {
                Text = "Card Example",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                FontAttributes = FontAttributes.Bold
            },
            new BoxView
            {
                Color = Color.Gray,
                HeightRequest = 2,
                HorizontalOptions = LayoutOptions.Fill
            },
            new Label
            {
                Text = "Frames can wrap more complex layouts to create more complex UI components, such as this card!"
            }
        }
                }
            };
        }

    }
}
