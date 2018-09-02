using Prism.Mvvm;

namespace SampleBinding.Models
{
    public class PC : BindableBase
    {
        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _ip;
        public string IP
        {
            get => _ip;
            set => SetProperty(ref _ip, value);
        }
    }
}
