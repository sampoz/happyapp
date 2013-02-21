﻿using System;
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
        public string Password { get; set; }
        public List<Task> Favourites { get; set; }
        
        public User(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;

            this.Favourites = new List<Task>();
            this.Favourites.Add(new Task("Madness", "tietoa"));
            this.Favourites.Add(new Task("Sparta","tietoa"));

        }
    }
}
