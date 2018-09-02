using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using SampleBinding.Models;
using SampleBinding.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.ViewManagement;

namespace SampleBinding.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<PC> PCs { get; } = new ObservableCollection<PC>();
        private List<PC> _sampleData;

        private INavigationService _navigationService;
        private IPCService _pcService;

        public MainViewModel(
            INavigationService navigationService,
            IPCService pcService)
        {
            _navigationService = navigationService;
            _pcService = pcService;
            _sampleData = _pcService.PCs;
            _sampleData.ForEach(PCs.Add);
        }

        public async void ChangeIPAfter5Seconds()
        {
            await Task.Run(async () =>
            {
                for (int i = 1; i <= 5; i++)
                {
                    await Task.Delay(1000);
                    Debug.WriteLine($"{i} seconds have passed");
                }
                var currentView = CoreApplication.MainView;
                await currentView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    _pcService.PCs[0].IP = "11.22.33.44";
                });
            });
        }

        public void NavigateToSubPage()
        {
            _navigationService.Navigate(PageTokens.SubPage, null);
        }
    }
}
