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
using Microsoft.Phone.Tasks;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;

namespace MiniBrowser
{
    public partial class MainPage : PhoneApplicationPage
    {
        private bool scrolling = false;
        private bool deleteItem = false;
        private bool markAsComplete = false;

        private ObservableCollection<string> _items = new ObservableCollection<string>();
        public ObservableCollection<string> Items
        {
            get { return _items; }
        }



        public MainPage()
        {
            InitializeComponent();

            List<string> favourites = new List<string>();
            foreach (Task t in App.User.Favourites)
                Items.Add(t.Name);

            usernameLabel.Text = App.User.Username;

            //    favouriteList.ItemsSource = favourites;

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
                markAsComplete = true;
            }
            else if (e.NewState.Name == "CompressionRight")
            {
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
                var item = (e.Control as ScrollViewer).DataContext.ToString();

                // List<string> favourites = (List<string>)favouriteList.ItemsSource;


                //favourites.Remove(item);
                //favouriteList.ItemsSource = favourites;

                deleteItem = false;
            }
            else if (scrolling)
            {
                if (markAsComplete)
                {
                    var sv = e.Control as ScrollViewer;
                    var sp = sv.Content as StackPanel;
                    var textBlock = sp.Children[0] as TextBlock;
             
                        
                        usernameLabel.Text =  textBlock.Text;
                      /*  var line = new Line()
                        {
                            Stroke = new SolidColorBrush(Colors.White),
                            StrokeThickness = 2,
                            X1 = 0,
                            Y1 = textBlock.ActualHeight / 2,
                            X2 = textBlock.ActualWidth,
                            Y2 = textBlock.ActualHeight / 2
                        };

                        centralPanel.Children.Add(line);*/
                    
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
                //(e.Control as ScrollViewer).ScrollToHorizontalOffset(150);
            }

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

        private void Search_Click(object sender, RoutedEventArgs e)
        {
           
        }
        private void Create_task(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Create_task.xaml",UriKind.Relative));
        }
        }
    }
