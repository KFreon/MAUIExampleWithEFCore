using System.Collections.ObjectModel;
using System.Windows.Input;
using MAUIExampleDB;
using MAUIExampleWithEFCore.Services;
using MAUIExampleWithEFCore.Views.Popups;

namespace MAUIExampleWithEFCore.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IMyService myService;
        private readonly Config config;

        public string Title => config.SiteName;

        public ObservableCollection<MyModel> Models { get; set; } = new ObservableCollection<MyModel>();

        private string name;
        public string Name
        {
            get => name;
            set => Set(ref name, value);
        }

        public ICommand AddCommand { get; set; }
        public ICommand PopInfo { get; set; }
        public ICommand PopCats { get; set; }
        private readonly IRepo repo;
        private readonly IPopupService popupService;

        public MainPageViewModel(IMyService myService, Config config, IRepo repo, IPopupService popupService)
        {
            AddCommand = new Command(AddModel, () => !IsBusy);
            PopInfo = new Command(ShowInfoPopup, () => !IsBusy);
            PopCats = new Command(ShowCatsPopup, () => !IsBusy);

            this.myService = myService;
            this.config = config;
            this.repo = repo;
            this.popupService = popupService;
        }

        public async Task Initialise()
        {
            await repo.MigrateAsync();
            await RefreshModels();
        }

        private async void AddModel()
        {
            popupService.ShowPopup<LoadingPopup>();

            var newModel = new MyModel
            {
                Id = Name.GetHashCode(), // Illustration only, I know it's bad.
                Name = Name
            };
            await myService.AddModel(newModel);

            await RefreshModels();

            await Task.Delay(2000);  // Fake work

            popupService.HidePopup();
        }

        private async Task RefreshModels()
        {
            Models.Clear();
            var things = await myService.GetThings();
            foreach (var thing in things)
            {
                Models.Add(thing);
            }
        }

        private void ShowInfoPopup()
        {
            popupService.ShowPopup<ContentPopup, ContentPopupViewModel>(model =>
            {
                model.Title = "Info about this app";
                model.Content = "This is an attempt to show how MAUI can be used more easily in a production scenario. That is, I'm using processes like those described in this app in a production app.";
            });
        }

        private void ShowCatsPopup()
        {
            popupService.ShowPopup<ContentPopup, ContentPopupViewModel>(model =>
            {
                model.Title = "Cats are great!";
                model.Content = "They're cute, cuddly, and adorable little murder machines 😻";
            });
        }
    }
}
