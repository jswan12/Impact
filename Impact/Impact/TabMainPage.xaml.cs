﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Impact
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class TabMainPage : TabbedPage
    {
        public TabMainPage()
        {
            InitializeComponent();
            this.CurrentPage = this.Children[4];
        }
    }
}
