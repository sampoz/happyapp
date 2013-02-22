using System;
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
        private String TopTasks;
        public StatsPage()
        {
            InitializeComponent();
            SetFace();
            double maxWidth = 450;
            double unit = maxWidth / 100;
            double initPosition = maxWidth / 2;
            if(App.User.giveStatus() * unit + initPosition > maxWidth)
                HealthBar.Width = maxWidth;
            if (App.User.giveStatus() * unit + initPosition < 0)
                HealthBar.Width = 0;
            else
                HealthBar.Width = App.User.giveStatus() * unit + initPosition;
            TopTasks = App.User.giveTopTasks();
            topTasks.Text = TopTasks;
        }

        public void SetFace()
        {
            var happy = App.User.giveStatus();
            String pic = "";
            if (happy < -25)
            {
                RollFace.Stop();
                RollFace.Seek(System.TimeSpan.FromTicks(0));
                pic = "derpherp_sad.png";
            }
            else if (happy < 10)
            {
                RollFace.Stop();
                RollFace.Seek(System.TimeSpan.FromTicks(0));
                pic = "derpherp_okay.png";
            }
            else
            {
                RollFace.RepeatBehavior = new RepeatBehavior(100);
                RollFace.Begin();
                pic = "derpherp.png";
            }
            pic = "/MiniBrowser;component/" + pic;
            Uri uri = new Uri(pic, UriKind.Relative);
            ImageSource imgSource = new BitmapImage(uri);
            face.Source = imgSource;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
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