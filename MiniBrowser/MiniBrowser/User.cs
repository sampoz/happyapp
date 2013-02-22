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
using System.Collections.ObjectModel;

namespace MiniBrowser
{
    public class User
    {
        public string Username { get; set; }


        private List<Task> _favourites = new List<Task>();
        public List<Task> Favourites { get { return _favourites; } set { _favourites = value; } }

        public string Password { get; set; }
   
        public List<Task> doneTasks = new List<Task>();

        
        public User(string Username)
        {
            this.Username = Username;
            

            this.Favourites = App.tasks;
            

        }
        public void addTask(Task taski)
        {
            this.doneTasks.Add(taski);
       
        }
        public ObservableCollection<string> giveTopTasks()
        {
            ObservableCollection<string> Items = new ObservableCollection<string>();
            foreach(Task task in this.doneTasks){
                Items.Add(task.getName());
                
            }
            return Items;
        }
        public int giveStatus()
        {
            int sum = 0;
            int status = 0;
            for (int i = 0; i < this.doneTasks.Count; i++ )
            {
                Task task = this.doneTasks[i];
                sum += task.status;
            }

            if (status > 100)
            {
                status = 100;
            }
            return status;
             
        }
    }
}
