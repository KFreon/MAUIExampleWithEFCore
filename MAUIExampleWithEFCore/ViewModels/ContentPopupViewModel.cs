using System.Windows.Input;
using MAUIExampleWithEFCore.Services;

namespace MAUIExampleWithEFCore.ViewModels
{
    public class ContentPopupViewModel : ViewModelBase
    {
        private readonly IPopupService popupService;

        public string Title { get; set; }
        public string Content { get; set; }

        public ICommand CloseCommand => new Command(Close, () => !IsBusy);

        public ContentPopupViewModel(IPopupService popupService)
        {
            this.popupService = popupService;
        }

        public void Close()
        {
            popupService.HidePopup();  // Really, this should hide this specific popup, but for now, this will do.
        }
    }
}
