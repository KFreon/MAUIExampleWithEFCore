namespace MAUIExampleWithEFCore.Views.Controls;

public partial class NiceEntry : ContentView
{
    public NiceEntry()
    {
        InitializeComponent();
    }

    public static BindableProperty IsPasswordProperty = BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(NiceEntry), false);

    public static BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(NiceEntry), null);

    public static BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(NiceEntry), null, BindingMode.TwoWay);

    public static BindableProperty ReturnTypeProperty = BindableProperty.Create(nameof(ReturnType), typeof(ReturnType), typeof(NiceEntry), ReturnType.Default);

    public static BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(NiceEntry), null);
    public static BindableProperty LabelColorProperty = BindableProperty.Create(nameof(LabelColor), typeof(Color), typeof(NiceEntry), null);

    public static BindableProperty KeyboardProperty = BindableProperty.Create(nameof(Keyboard), typeof(Keyboard), typeof(NiceEntry), Keyboard.Default);

    public static BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize), typeof(string), typeof(NiceEntry), "24");

    public static BindableProperty ReturnCommandProperty = BindableProperty.Create(nameof(ReturnCommand), typeof(Command), typeof(NiceEntry), null);

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
        thelabel.ScaleTo(0.7, easing: Easing.CubicInOut);
        thelabel.TranslateTo(0, -20, easing: Easing.CubicInOut);
    }
    private void RestoreLabel()
    {
        thelabel.ScaleTo(1, easing: Easing.CubicInOut);
        thelabel.TranslateTo(0, 0, easing: Easing.CubicInOut);
    }

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