using Unity;

namespace dotValidate.Registration
{
    /// <summary>
    /// Unity Extensions for <i>dotValidate</i>/>
    /// </summary>
    public static class UnityExtensions
    {
        /// <summary>
        /// Register <i>dotValidate</i>/> in your UnityConfig 
        /// </summary>
        public static void RegisterDotValidate(this IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<IValidator, Validator>();
        }
    }
}
