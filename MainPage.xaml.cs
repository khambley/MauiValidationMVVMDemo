using MauiValidationMVVMDemo.ViewModels;

namespace MauiValidationMVVMDemo;

public partial class MainPage : ContentPage
{
    private readonly MainViewModel _viewModel;

    public MainPage(MainViewModel viewModel)
	{
        BindingContext = _viewModel = viewModel;
        InitializeComponent();
	}

    void Entry_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
    }

}


