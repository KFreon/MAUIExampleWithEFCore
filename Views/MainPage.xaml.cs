using MAUIExampleWithEFCore.ViewModels;

namespace MAUIExampleWithEFCore.Views;

public partial class MainPage : ContentPage
{
	public MainPage(MainPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    protected override async void OnAppearing()
    {
		await (BindingContext as MainPageViewModel)?.Initialise();
        base.OnAppearing();
    }
}