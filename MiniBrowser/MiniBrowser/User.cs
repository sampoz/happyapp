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
        public String giveTopTasks()
        {
            String Items = "";
            Dictionary<String, int> topTasks = new Dictionary<String, int> ();
            foreach (Task task in this.doneTasks)
            {
                if (!topTasks.ContainsKey(task.getName()))
                {
                    topTasks.Add(task.getName(), task.status);
                }
                else {
                    int temp = topTasks[task.getName()];
                    topTasks[task.getName()] = temp + task.status;
                }
            }
            foreach (KeyValuePair<string, int> pair in topTasks)
            {
                Items += pair.Key;
                Items += "  ";
                if(pair.Value > 0)
                Items += "+";
                Items += pair.Value;
                Items += Environment.NewLine;

            }
       
            return Items;
        }
        public int giveStatus()
        {
            
            int status = 0;
            for (int i = 0; i < this.doneTasks.Count; i++ )
            {
                Task task = this.doneTasks[i];
                status += task.status;
            }

            return status;
             
        }
    }
}
