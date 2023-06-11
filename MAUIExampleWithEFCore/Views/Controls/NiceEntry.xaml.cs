namespace MAUIExampleWithEFCore.Views.Controls;

public partial class NiceEntry : ContentView
{
    public NiceEntry()
    {
        InitializeComponent();
    }

    // These are the properties that are exposed when using this component.
    // Akin to props in React.
    public static BindableProperty IsPasswordProperty = BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(NiceEntry), false);
    public static BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(NiceEntry), null);
    public static BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(NiceEntry), null, BindingMode.TwoWay);
    public static BindableProperty ReturnTypeProperty = BindableProperty.Create(nameof(ReturnType), typeof(ReturnType), typeof(NiceEntry), ReturnType.Default);
    public static BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(NiceEntry), null);
    public static BindableProperty LabelColorProperty = BindableProperty.Create(nameof(LabelColor), typeof(Color), typeof(NiceEntry), null);
    public static BindableProperty KeyboardProperty = BindableProperty.Create(nameof(Keyboard), typeof(Keyboard), typeof(NiceEntry), Keyboard.Default);
    public static BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize), typeof(string), typeof(NiceEntry), "24");
    public static BindableProperty ReturnCommandProperty = BindableProperty.Create(nameof(ReturnCommand), typeof(Command), typeof(NiceEntry), null);

    // These can be considered "private" properties, even though they aren't.
    // Despite being public, they can't be seen by the xaml editor without their matching BindableProperty.
    public Color TextColor
    {
        get => (Color)GetValue(TextColorProperty);
        set => SetValue(TextColorProperty, value);
    }

    public Color LabelColor
    {
        get => (Color)GetValue(LabelColorProperty);
        set => SetValue(LabelColorProperty, value);
    }

    public string FontSize
    {
        get => (string)GetValue(FontSizeProperty);
        set => SetValue(FontSizeProperty, value);
    }

    public Keyboard Keyboard
    {
        get => (Keyboard)GetValue(KeyboardProperty);
        set => SetValue(KeyboardProperty, value);
    }

    public bool IsPassword
    {
        get => (bool)GetValue(IsPasswordProperty);
        set => SetValue(IsPasswordProperty, value);
    }

    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set
        {
            SetValue(TextProperty, value);
            var noText = string.IsNullOrEmpty(value);

            // Deciding whether to animate or not.
            if (!noText)
            {
                MakeLabelSmall();
            }

            if (noText)
            {
                RestoreLabel();
            }
        }
    }

    public ReturnType ReturnType
    {
        get => (ReturnType)GetValue(ReturnTypeProperty);
        set => SetValue(ReturnTypeProperty, value);
    }

    public Command ReturnCommand
    {
        get => (Command)GetValue(ReturnCommandProperty);
        set => SetValue(ReturnCommandProperty, value);
    }

    private void MakeLabelSmall()
    {
        // Animations are async, and we could await these if you want them to be sequential.
        // I want them to occur at the same time, hence no awaiting.
        thelabel.ScaleTo(0.7, easing: Easing.CubicInOut);
        thelabel.TranslateTo(0, -20, easing: Easing.CubicInOut);  // Cubic easing is pleasing.
    }
    private void RestoreLabel()
    {
        thelabel.ScaleTo(1, easing: Easing.CubicInOut);
        thelabel.TranslateTo(0, 0, easing: Easing.CubicInOut);
    }

    // This doesn't work reliably for some reason.
    // It's supposed to trigger the animation when focus changes, but it...doesn't...
    // Most of the time anyway...
    private void Entry_FocusChanged(object sender, FocusEventArgs e)
    {
        if (e.IsFocused)
        {
            MakeLabelSmall();
        }

        if (string.IsNullOrEmpty(Text))
        {
            RestoreLabel();
        }
    }
}