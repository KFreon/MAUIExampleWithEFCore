using System.Windows.Input;
using MAUIExampleWithEFCore.Services;

namespace MAUIExampleWithEFCore.ViewModels
{
    public class ContentPopupViewModel : ViewModelBase
    {
        private readonly IPopupService popupService;

        // Note that these aren't those special UI friendly properties.
        // They don't need to be as their value isn't bound in xaml, and doesn't change after OnAppearing
        public string Title { get; set; }
        public string Content { get; set; }

        public ICommand CloseCommand => new Command(Close, () => !IsBusy);

        public ContentPopupViewModel(IPopupService popupService)
        {
            this.popupService = popupService;
        }

        public void Close()
        {
            popupService.HidePopup();
        }
    }
}
