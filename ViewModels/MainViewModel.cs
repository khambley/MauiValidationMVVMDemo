using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiValidationMVVMDemo.Validations;

namespace MauiValidationMVVMDemo.ViewModels
{
	public partial class MainViewModel : ObservableObject
	{
		[ObservableProperty]
		private ValidatableObject<string> _password = new();

		[ObservableProperty]
		private ValidatableObject<string> _userName = new();

		[ObservableProperty]
		private ValidatableObject<int> _itemQuantity = new();

		[ObservableProperty]
        private bool _isValid;

        public MainViewModel()
		{
		}
		[RelayCommand]
		private async Task LoginAsync()
		{
			AddValidationRules();
			var isValid = UserName.Validate() && ItemQuantity.Validate();
			if (isValid)
			{
				var username = UserName;
				var unValue = UserName.Value;
				var qtyValue = ItemQuantity.Value;
				await Shell.Current.DisplayAlert("Username Valid", "Username is valid", "OK");
			}
			else
			{
                await Shell.Current.DisplayAlert("Username Not Valid", "Username is not valid", "OK");
            }
		}

        [RelayCommand]
        private void Validate()
        {
            AddValidationRules();
            IsValid = ItemQuantity.Validate();
        }
        private void AddValidationRules()
		{
            UserName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A username is required." });
            Password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A password is required." });
			ItemQuantity.Validations.Add(new IsGreaterThanZeroRule<int> { ValidationMessage = "A quantity greater than zero is required." });
			ItemQuantity.Validations.Add(new IsNotNullOrEmptyRule<int> { ValidationMessage = "A quantity value is required." });
        }

    }
}

