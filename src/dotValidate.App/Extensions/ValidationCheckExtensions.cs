using dotValidate.Models;

namespace dotValidate
{
    /// <summary>
    /// Property Extensions for building Validation Rules with dotValidate
    /// </summary>
    public static partial class PropertyExtensions
    {
        /// <summary>
        /// <b>Use Custom Message</b><br/>
        /// Allows a user defined error message to be returned in the event of the check in question failing
        /// </summary>
        /// <typeparam name="T">Type of Validation Check</typeparam>
        /// <param name="test">Validation Check</param>
        /// <param name="message">Custom Message Text</param>
        /// <returns>Validation Check with Custom Message rule appled</returns>
        public static T UseCustomMessage<T>(this T test, string message)
            where T : ValidationCheck
        {
            test.SetCustomMessage(message);

            return test;
        }

        /// <summary>
        /// <b>Stop Validation On Failure</b><br/>
        /// Allows a safety check to stop any further validation checks being run if the check in question fails
        /// </summary>
        /// <typeparam name="T">Type of Validation Check</typeparam>
        /// <param name="test">Validation Check</param>
        /// <returns>Validation Check with Stop-If-Fails rule appled</returns>
        public static T StopValidationOnFailure<T>(this T test)
            where T : ValidationCheck
        {
            test.StopValidatingOnFailure();

            return test;
        }

        internal static ValidationCheck Inverted(this ValidationCheck check)
        {
            check.InvertResult();

            return check;
        }
    }
}