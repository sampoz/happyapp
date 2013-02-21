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
using Microsoft.Phone.Controls;

namespace MiniBrowser
{

    public static class Navigation
    {

        public static void GoToPage(this PhoneApplicationPage currentPage, Pages page, String id)
        {
            switch (page)
            {
                case (Pages.Main):
                currentPage.NavigationService.Navigate(new Uri("/MainPage.xaml",UriKind.Relative));
                break;

                case (Pages.Action):
                String uri = "/TaskPage.xaml?Text="+id;
                currentPage.NavigationService.Navigate(new Uri(uri, UriKind.Relative));
                break;

                case (Pages.CreateTask):
                currentPage.NavigationService.Navigate(new Uri("/CreateTask.xaml", UriKind.Relative));
                break;

            }
        }



    }
}
