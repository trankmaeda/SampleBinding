using System;

using SampleBinding.ViewModels;

using Windows.UI.Xaml.Controls;

namespace SampleBinding.Views
{
    public sealed partial class MainPage : Page
    {
        private MainViewModel ViewModel => DataContext as MainViewModel;

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
