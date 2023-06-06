using CommunityToolkit.Maui.Views;

namespace MAUIExampleWithEFCore.Views.Popups;

public partial class LoadingPopup : Popup
{
	public LoadingPopup()
	{
		InitializeComponent();
		_ = RotateForLoading();
	}

	private async Task RotateForLoading()
	{
		while (true)
		{
			await image.RelRotateTo(180, 1000);
			await Task.Delay(500);
		}
	}
}