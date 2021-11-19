using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TestApi.Service;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TestApi.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ListView : Page
    {
        private PhotoService photoService = new PhotoService();

        public ListView()
        {
            this.InitializeComponent();
            this.Loaded += ListPhoto_LoadedAsync;
        }

        private async void ListPhoto_LoadedAsync(object sender, RoutedEventArgs e)
        {
            var ListSong = await photoService.GetPhotoAsync();
            MyListView.ItemsSource = ListSong;
        }
    }
}
