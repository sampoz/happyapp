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


namespace MiniBrowser
{
    public partial class NewUser : PhoneApplicationPage
    {
        public NewUser()
        {
            InitializeComponent();
            OpenSesame.Completed += new EventHandler(OpenSesame_Completed);
        }

        public void submitNewUser(object render, RoutedEventArgs e)
        {

            
                App.User = new User(nameInput.Text);
                OpenSesame.Begin();
            
        }

        void OpenSesame_Completed(object sender, EventArgs e)
        {
            Navigation.GoToPage(this, Pages.Main, null);
        }
    }
}