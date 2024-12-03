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
            //Validate();
			if (Validate())
			{
                await Shell.Current.DisplayAlert("Validation Successful", "Username, Password and ItemQty are valid", "OK");
            }
		}

        private bool ValidateUserName()
		{
			return UserName.Validate();
		}

        private bool ValidatePassword()
        {
            return Password.Validate();
        }

		private bool ValidateItemQuantity()
		{
			return ItemQuantity.Validate();
		}

		private bool Validate()
		{
			bool isValidUser = ValidateUserName();
			bool isValidPassword = ValidatePassword();
			bool isValidItemQuantity = ValidateItemQuantity();
			//IsValid = UserName.IsValid && Password.IsValid && ItemQuantity.IsValid;
            return isValidUser && isValidPassword && isValidItemQuantity;
        }

		private void AddValidationRules()
		{
            UserName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A username is required." });
            Password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A password is required." });
			ItemQuantity.Validations.Add(new IsGreaterThanZeroRule<int> { ValidationMessage = "A quantity greater than zero is required." });
        }

    }
}

