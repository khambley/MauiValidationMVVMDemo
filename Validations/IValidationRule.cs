using System;
namespace MauiValidationMVVMDemo.Validations
{
	public interface IValidationRule<T>
    {
        string ValidationMessage { get; set; }

        bool Check(T value);
    }
}

