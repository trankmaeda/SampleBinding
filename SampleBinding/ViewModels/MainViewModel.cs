using Newtonsoft.Json;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using SampleBinding.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace SampleBinding.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<PC> PCs { get; } = new ObservableCollection<PC>();
        private List<PC> _sampleData;

        private INavigationService _navigationService;

        public MainViewModel(INavigationService navigationService)
        {
            _sampleData = GetSampleData();
            _sampleData.ForEach(PCs.Add);
            _navigationService = navigationService;
        }

        public void NavigateToSubPage()
        {
            var serializedPC = JsonConvert.SerializeObject(_sampleData);
            Debug.WriteLine($"Serialized PC = {serializedPC}");
            _navigationService.Navigate(PageTokens.SubPage, serializedPC);
        }

        public List<PC> GetSampleData()
        {
            return new List<PC>
            {
                new PC
                {
                    Name = "ServerA",
                    IP = "10.2.0.1"
                },
                new PC
                {
                    Name = "ServerB",
                    IP = "192.168.1.1"
                },
                new PC
                {
                    Name = "ServerC",
                    IP = "192.168.10.0"
                },
                new PC
                {
                    Name = "ServerD",
                    IP = "10.11.1.0"
                }
            };
        }
    }
}
