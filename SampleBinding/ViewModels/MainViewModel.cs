using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using SampleBinding.Models;
using SampleBinding.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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

        public void NavigateToSubPage()
        {
            _navigationService.Navigate(PageTokens.SubPage, null);
        }
    }
}
