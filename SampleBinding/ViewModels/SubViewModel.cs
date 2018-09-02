using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using SampleBinding.Models;
using SampleBinding.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Navigation;

namespace SampleBinding.ViewModels
{
    public class SubViewModel : ViewModelBase
    {
        public ObservableCollection<PC> PCs { get; } = new ObservableCollection<PC>();
        private List<PC> _sampleData;

        private INavigationService _navigationService;
        private IPCService _pcService;

        public SubViewModel(
            INavigationService navigationService,
            IPCService pcService)
        {
            _navigationService = navigationService;
            _pcService = pcService;
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);

            if (e.NavigationMode == NavigationMode.New)
            {
                _sampleData = _pcService.PCs;
                _sampleData.ForEach(PCs.Add);
            }
        }

        public void SortPCs()
        {
            PCs.Clear();
            _sampleData.Sort((a, b) => Version.Parse(a.IP).CompareTo(Version.Parse(b.IP)));
            _sampleData.ForEach(PCs.Add);
        }

        public void ChangeIP()
        {
            PCs[0].IP = "192.168.99.9";
        }

        public void NavigateToMainPage()
        {
            _navigationService.Navigate(PageTokens.MainPage, null);
        }
    }
}
