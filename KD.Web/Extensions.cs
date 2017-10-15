using System.Security;

namespace KD.Web
{
    /// <summary>
    /// Contains various extension methods.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Converts current <see cref="string"/> to <see cref="SecureString"/>.
        /// </summary>
        public static SecureString ToSecure(this string str)
        {
            var secure = new SecureString();
            foreach (var ch in str) secure.AppendChar(ch);
            return secure;
        }
    }
}