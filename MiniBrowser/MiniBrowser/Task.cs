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

namespace MiniBrowser
{
    public class Task
    {
        String name { get; set; }
        String description { get; set; }
        int healthy;
        public Task(String name, String des)
        {
            this.name = name;
            this.description = des;
        }
        public String getName()
        {
            return this.name;
        }
        public void setName(String name)
        {
            this.name = name;
        }
        public void setHealthy(int h)
        {
            this.healthy = h;
        }
        public int getHealthy()
        {
            return this.healthy;
        }

    }
}
