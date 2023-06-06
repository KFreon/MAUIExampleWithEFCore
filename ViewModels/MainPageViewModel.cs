using System.Collections.ObjectModel;
using System.Windows.Input;
using MAUIExampleDB;
using MAUIExampleWithEFCore.Services;

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
        private readonly IRepo repo;

        public MainPageViewModel(IMyService myService, Config config, IRepo repo)
        {
            AddCommand = new Command(AddModel, () => !IsBusy);
            this.myService = myService;
            this.config = config;
            this.repo = repo;
        }

        public async Task Initialise()
        {
            await repo.MigrateAsync();
            await RefreshModels();
        }

        private async void AddModel()
        {
            var newModel = new MyModel
            {
                Id = Name.GetHashCode(), // Illustration only, I know it's bad.
                Name = Name
            };
            await myService.AddModel(newModel);

            await RefreshModels();
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
    }
}
