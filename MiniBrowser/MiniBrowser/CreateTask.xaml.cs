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
    public partial class CreateTask : PhoneApplicationPage
    {
        public CreateTask()
        {
            InitializeComponent();
        }
        private void submitNewTask(object render, RoutedEventArgs e)
        {
            Console.WriteLine("task name ", task_name.Text);
            if (!task_name.Text.Equals("") || !task_des.Text.Equals(""))
            {
                Task task = new Task(task_name.Text, task_des.Text,null);
                App.tasks.Add(task);
                Navigation.GoToPage(this, Pages.Main, null);
            }
            else
                emptyError.Visibility = Visibility.Visible;
            }
    }
}