using System;

namespace JustDeclare.Exceptions
{
    public class ValidationSetupException : Exception
    {
        public ValidationSetupException(string message)
            : base($"The following Setup error was made when writing a RequestValidator: {message}")
        {
        }

        public static ValidationSetupException NoArgumentsToMethodCall()
        {
            return new ValidationSetupException("There was no argument passed to a method which creates a validation test");
        }
    }
}