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
using System.Collections;
using System.Collections.ObjectModel;
using Microsoft.Phone.Controls;
using System.Windows.Media.Imaging;

namespace MiniBrowser
{
    public partial class TaskPage : PhoneApplicationPage
    {
        private bool markAsComplete = false;
        private bool deleteItem = false;
        private bool scrolling = false;
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

        private void setStatusNumber()
        {
            if (this.task.status > 0)
            {
                statusNumber.Text = "+" + this.task.status;
            }
            else
            {
                statusNumber.Text = ""+this.task.status;
            }
        }


        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            IDictionary<string, string> parameters = this.NavigationContext.QueryString;
            if(parameters.ContainsKey("Text")){
                String id = parameters["Text"];
                 this.task = App.tasks.First(a => a.getName() == id);
                 taskDesc.Text = this.task.Description;
                 setStatusNumber();         
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
            App.main.SetFace();
        }
        

        public void ScrollViewer_Loaded(object sender, RoutedEventArgs e)
        {
            var sv = sender as ScrollViewer;

            if (sv != null)
            {
                //sv.ScrollToHorizontalOffset(150);
                // Visual States are always on the first child of the control template
                FrameworkElement element = VisualTreeHelper.GetChild(sv, 0) as FrameworkElement;
                if (element != null)
                {
                    VisualStateGroup group = FindVisualState(element, "ScrollStates");
                    if (group != null)
                    {
                        group.CurrentStateChanging += new EventHandler<VisualStateChangedEventArgs>(group_CurrentStateChanging);
                    }
                    VisualStateGroup hgroup = FindVisualState(element, "HorizontalCompression");
                    if (hgroup != null)
                    {
                        hgroup.CurrentStateChanging += new EventHandler<VisualStateChangedEventArgs>(hgroup_CurrentStateChanging);
                    }
                }
            }
        }

        void hgroup_CurrentStateChanging(object sender, VisualStateChangedEventArgs e)
        {
            if (e.NewState.Name == "CompressionLeft")
            {
                deleteItem = true;
            }
            else if (e.NewState.Name == "CompressionRight")
            {
                markAsComplete = true;
                // Do nothing
            }
            else if (e.NewState.Name == "NoHorizontalCompression" && !scrolling)
            {
                deleteItem = false;
                markAsComplete = false;
            }
        }

        void group_CurrentStateChanging(object sender, VisualStateChangedEventArgs e)
        {
            if (scrolling && deleteItem)
            {
               

                // List<string> favourites = (List<string>)favouriteList.ItemsSource;

                
                //favourites.Remove(item);
                //favouriteList.ItemsSource = favourites;
                this.task.status -= 1;
                setStatusNumber();
                deleteItem = false;
            }
            else if (scrolling)
            {
                if (markAsComplete)
                {
                    //var sv = e.Control as ScrollViewer;
                    //var sp = sv.Content as StackPanel;
                    //var textBlock = sp.Children[0] as TextBlock;

                    //Navigation.GoToPage(this, Pages.Action, textBlock.Text);

                    this.task.status += 1;
                    setStatusNumber();
                    markAsComplete = false;
                }
                
            }
            var storyboard = new Storyboard();
            var animation = new DoubleAnimation()
            {
                Duration = TimeSpan.FromMilliseconds(300),
                From = (e.Control as ScrollViewer).HorizontalOffset,
                To = 150,
                EasingFunction = new CubicEase()
                {
                    EasingMode = EasingMode.EaseOut
                }
            };
            Storyboard.SetTarget(animation, e.Control.Tag as ScrollViewerOffsetMediator);
            Storyboard.SetTargetProperty(animation, new PropertyPath(ScrollViewerOffsetMediator.HorizontalOffsetProperty));

            storyboard.Children.Add(animation);
            storyboard.Begin();
            (e.Control as ScrollViewer).ScrollToHorizontalOffset(150);
            scrolling = e.NewState.Name == "Scrolling";
        }

        private VisualStateGroup FindVisualState(FrameworkElement element, string name)
        {
            if (element == null)
                return null;

            IList groups = VisualStateManager.GetVisualStateGroups(element);
            foreach (VisualStateGroup group in groups)
                if (group.Name == name)
                    return group;

            return null;
        }
    }
}