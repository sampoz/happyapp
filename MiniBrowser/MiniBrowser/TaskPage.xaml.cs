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
    public partial class TaskPage : PhoneApplicationPage
    {
        private Task task;
        public TaskPage(String task_name)
        {
            InitializeComponent();
            this.task = App.tasks.First(a => a.getName() == task_name);
            if (this.task == null)
            {
                Navigation.GoToPage(this, Pages.Main);
            }

        }
        public void Rate_healthy(object sender, RoutedEventArgs e)
        {
            int h = task.getHealthy();
            task.setHealthy(h + 1);
        }

    }
}