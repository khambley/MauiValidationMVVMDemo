using System;
namespace MauiValidationMVVMDemo.Validations
{
	public class IsGreaterThanZeroRule<T> : IValidationRule<T>
	{
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            return value is int number && number > 0;
        }
    }
}

