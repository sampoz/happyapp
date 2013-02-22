using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;

namespace MiniBrowser
{
    public class User
    {
        public string Username { get; set; }

        private List<Task> _favourites = new List<Task>();
        public List<Task> Favourites { get { return _favourites; } set { _favourites = value; } }
        
        public User(string Username)
        {
            this.Username = Username;
            

            this.Favourites = App.tasks;
            

        }
    }
}
