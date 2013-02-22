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
        public string Password { get; set; }
        public List<Task> Favourites { get; set; }
        public List<Task> doneTasks = new List<Task>();
        
        public User(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;

            this.Favourites = App.tasks;
            

        }
        public void addTask(Task taski)
        {
            this.doneTasks.Add(taski);
       
        }
    }
}
