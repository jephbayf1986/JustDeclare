using System;

namespace dotValidate.Exceptions
{
    /// <summary>
    /// <b>dotValidate Validation Setup Exception</b> <br />
    /// Thrown when setup for validation rules fails - Should never be thrown!
    /// </summary>
    public class ValidationSetupException : Exception
    {
        internal ValidationSetupException(string message)
            : base($"The following Setup error was made when writing a RequestValidator: {message}")
        {
        }

        internal static ValidationSetupException NoArgumentsToMethodCall()
        {
            return new ValidationSetupException("There was no argument passed to a method which creates a validation test");
        }
    }
}