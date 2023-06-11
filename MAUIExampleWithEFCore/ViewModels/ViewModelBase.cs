using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MAUIExampleWithEFCore.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        // Required to trigger change detection in xaml.
        public event PropertyChangedEventHandler PropertyChanged;

        // Not really using this here, but I use this to power loading spinners.
        internal bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => Set(ref _isBusy, value);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        // Convenience method to easily set properties and matching change detection.
        protected bool Set<T>(ref T property, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (Equals(property, newValue))
            {
                return false;
            }

            property = newValue;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
