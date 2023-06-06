using MAUIExampleWithEFCore.Views;

namespace MAUIExampleWithEFCore;

public partial class App : Application
{
	public App(IServiceProvider services)
	{
		InitializeComponent();

        MainPage = services.GetRequiredService<MainPage>();  // Bug in DI regarding resolving StaticResources in xaml: https://github.com/dotnet/maui/issues/11485
    }
}