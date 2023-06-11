using CommunityToolkit.Maui.Views;
using MAUIExampleWithEFCore.ViewModels;

namespace MAUIExampleWithEFCore.Services
{
    public interface IPopupService
    {
        void ShowPopup<T, V>(Action<V> viewModelSetup = null) where T : Popup where V : ViewModelBase;
        Task ShowPopup<T, V>(Func<V, Task> viewModelSetup = null) where T : Popup where V : ViewModelBase;
        void ShowPopup<T>() where T : Popup;
        void HidePopup();
        void HideAllPopups();
    }

    public class PopupService : IPopupService
    {
        private readonly IServiceProvider services;

        // Need to keep track of the popups so we can close them.
        private Stack<Popup> popups = new();

        public PopupService(IServiceProvider services)
        {
            this.services = services;
        }

        /// <summary>
        /// Show popup.
        /// </summary>
        /// <typeparam name="T">Popup</typeparam>
        /// <exception cref="MissingMethodException"></exception>
        public void ShowPopup<T>() where T : Popup
        {
            var mainPage = App.Current?.MainPage ?? throw new MissingMethodException("Main page is null");
            var popup = services.GetRequiredService<T>();
            mainPage.ShowPopup<T>(popup);
            popups.Push(popup);
        }

        /// <summary>
        /// Show popup, allowing configuration of view model.
        /// </summary>
        /// <typeparam name="T">Popup</typeparam>
        /// <typeparam name="V">View Model</typeparam>
        /// <param name="viewModelSetup">Action to configure the view model.</param>
        /// <exception cref="MissingMethodException"></exception>
        public void ShowPopup<T, V>(Action<V> viewModelSetup = null) where T : Popup where V : ViewModelBase
        {
            var mainPage = App.Current?.MainPage ?? throw new MissingMethodException("Main page is null");
            var popup = services.GetRequiredService<T>();
            var viewModel = services.GetRequiredService<V>();
            viewModelSetup?.Invoke(viewModel);
            popup.BindingContext = viewModel;
            mainPage.ShowPopup(popup);
            popups.Push(popup);
        }

        /// <summary>
        /// Show popup, allowing asynchronous configuration of view model.
        /// </summary>
        /// <typeparam name="T">Popup</typeparam>
        /// <typeparam name="V">View Model</typeparam>
        /// <param name="viewModelSetup">Asynchronous delegate to configure view model</param>
        /// <returns></returns>
        /// <exception cref="MissingMethodException"></exception>
        public async Task ShowPopup<T, V>(Func<V, Task> viewModelSetup = null) where T : Popup where V : ViewModelBase
        {
            var mainPage = App.Current?.MainPage ?? throw new MissingMethodException("Main page is null");
            var popup = services.GetRequiredService<T>();
            var viewModel = services.GetRequiredService<V>();
            await viewModelSetup?.Invoke(viewModel);
            popup.BindingContext = viewModel;
            mainPage.ShowPopup(popup);
            popups.Push(popup);
        }

        public void HidePopup()
        {
            popups.Pop().Close();
        }

        public void HideAllPopups()
        {
            while (popups.Count > 0)
            {
                popups.Pop().Close();
            }
        }
    }
}
