using System;

using SampleBinding.ViewModels;

using Windows.UI.Xaml.Controls;

namespace SampleBinding.Views
{
    public sealed partial class TabbedPage : Page
    {
        private TabbedViewModel ViewModel => DataContext as TabbedViewModel;

        public TabbedPage()
        {
            InitializeComponent();
        }
    }
}
