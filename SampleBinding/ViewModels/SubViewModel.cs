using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Newtonsoft.Json;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using SampleBinding.Models;
using Windows.UI.Xaml.Navigation;

namespace SampleBinding.ViewModels
{
    public class SubViewModel : ViewModelBase
    {
        public ObservableCollection<PC> PCs { get; } = new ObservableCollection<PC>();
        private List<PC> _sampleData;

        private INavigationService _navigationService;

        public SubViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);

            if (e.NavigationMode == NavigationMode.New)
            {
                var pcList = e.Parameter as string;
                Debug.WriteLine($"Received PC   = {pcList}");
                _sampleData = JsonConvert.DeserializeObject<List<PC>>(pcList);
                _sampleData.ForEach(PCs.Add);
            }
        }

        public void SortPCs()
        {
            PCs.Clear();
            _sampleData.Sort((a, b) => Version.Parse(a.IP).CompareTo(Version.Parse(b.IP)));
            _sampleData.ForEach(PCs.Add);
        }

        public void NavigateToMainPage()
        {
            _navigationService.Navigate(PageTokens.MainPage, null);
        }
    }
}
