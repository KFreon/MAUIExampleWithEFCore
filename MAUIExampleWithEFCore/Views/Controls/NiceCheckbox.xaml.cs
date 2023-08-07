using System.Windows.Input;

namespace MAUIExampleWithEFCore.Views.Controls;

public partial class NiceCheckbox : ContentPage
{
    public NiceCheckbox()
    {
        CheckCommand = new Command(() => IsChecked = !IsChecked);
        InitializeComponent();
    }

    public ICommand CheckCommand { get; set; }

    public static BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(Label), null);

    public static BindableProperty IsCheckedProperty = BindableProperty.Create(nameof(IsChecked), typeof(bool), typeof(CheckBox), false, BindingMode.TwoWay);

    public static BindableProperty CheckboxColorProperty = BindableProperty.Create(nameof(CheckboxColor), typeof(Color), typeof(CheckBox), null);

    public static BindableProperty TextWrapProperty = BindableProperty.Create(nameof(TextWrap), typeof(LineBreakMode), typeof(CheckBox), LineBreakMode.WordWrap);

    public static BindableProperty LabelWidthProperty = BindableProperty.Create(nameof(LabelWidth), typeof(string), typeof(CheckBox), null);


    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public bool IsChecked
    {
        get => (bool)GetValue(IsCheckedProperty);
        set => SetValue(IsCheckedProperty, value);
    }

    public Color CheckboxColor
    {
        get => (Color)GetValue(CheckboxColorProperty);
        set => SetValue(CheckboxColorProperty, value);
    }

    public LineBreakMode TextWrap
    {
        get => (LineBreakMode)GetValue(TextWrapProperty);
        set => SetValue(TextWrapProperty, value);
    }

    public string LabelWidth
    {
        get => (string)GetValue(LabelWidthProperty);
        set => SetValue(LabelWidthProperty, value);
    }
}