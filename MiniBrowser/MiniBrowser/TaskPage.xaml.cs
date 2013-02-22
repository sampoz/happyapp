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

namespace MiniBrowser
{
    public partial class TaskPage : PhoneApplicationPage
    {
        private Task task;
        public TaskPage()
        {
            InitializeComponent();
            

        }
        public void Rate_healthy(object sender, RoutedEventArgs e)
        {
            int h = task.getHealthy();
            task.setHealthy(h + 1);
            
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            IDictionary<string, string> parameters = this.NavigationContext.QueryString;
            if(parameters.ContainsKey("Text")){
                String id = parameters["Text"];
                 this.task = App.tasks.First(a => a.getName() == id);
                 taskDesc.Text = this.task.Description;
                 PageTitle.Text = id;
                 if (this.task.getImgSrc() != null)
                 {

                     
                     String tempSrc = this.task.getImgSrc();
                     BitmapSource tn = new BitmapImage(new Uri(tempSrc, UriKind.Relative));
                         
                     //tn.SetSource(Application.GetResourceStream(new Uri(tempSrc, UriKind.Relative)).Stream);
                     image1.Source = tn;
                 }
            } else
                Navigation.GoToPage(this, Pages.Main, null);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            App.User.addTask(this.task);
        }
        
    }
}