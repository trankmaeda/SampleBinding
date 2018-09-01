using System;

using SampleBinding.ViewModels;

using Windows.UI.Xaml.Controls;

namespace SampleBinding.Views
{
    public sealed partial class SubPage : Page
    {
        private SubViewModel ViewModel => DataContext as SubViewModel;

        public SubPage()
        {
            InitializeComponent();
        }
    }
}
