﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;

namespace MiniBrowser
{
    public partial class StatsPage : PhoneApplicationPage
    {
        private ObservableCollection<string> _topTasks = new ObservableCollection<string>();
        ObservableCollection<string> TopTasks
        {
            get { return _topTasks; }
            set { _topTasks = value; }
        }
        public StatsPage()
        {
            InitializeComponent();

            double maxWidth = 450;
            double unit = maxWidth / 100;
            if(App.User.giveStatus() * 25  > maxWidth)
                HealthBar.Width = maxWidth;
            HealthBar.Width = App.User.giveStatus() * unit;
            TopTasks = App.User.giveTopTasks();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HealthFill.Begin();
            /*var unit = MyCanvas.ActualWidth / 4;
            HealthBar.Width += unit;
            if (HealthBar.Width > unit * 4) HealthBar.Width = 1;*/

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("/MiniBrowser;component/derpherp_sad.png", UriKind.Relative);
            ImageSource imgSource = new BitmapImage(uri);
            face.Source = imgSource; 
        }
    }
}