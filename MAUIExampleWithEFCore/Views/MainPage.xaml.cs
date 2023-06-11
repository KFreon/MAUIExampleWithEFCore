using MAUIExampleWithEFCore.ViewModels;

namespace MAUIExampleWithEFCore.Views;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;  // VM will be injected by DI, but requires further setup (probably cos it's async)
    }

    // Lifecycle event triggered when view is going to be shown
    // Makes it a good event to do setup on.
    protected override async void OnAppearing()
    {
		await (BindingContext as MainPageViewModel)?.Initialise();
        base.OnAppearing();
    }

    // Opposite event to above.
    // Good for any cleanup required.
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
    }
}