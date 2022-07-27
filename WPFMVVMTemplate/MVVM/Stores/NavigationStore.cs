using System;
using WPFMVVMTemplate.MVVM.ViewModels;

namespace WPFMVVMTemplate.MVVM.Stores
{
    public class NavigationStore
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        public event Action? CurrentViewModelChanged;
        private void OnCurrentViewModelChanged() { CurrentViewModelChanged?.Invoke(); }

        public NavigationStore() { _currentViewModel = new ViewModelBase(); }
    }
}