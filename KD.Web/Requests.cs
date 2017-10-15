using System.IO;
using System.Net;
using System.Text;

namespace KD.Web
{
    /// <summary>
    /// Contains various methods connected with sending Requests.
    /// </summary>
    public static class Requests
    {
        /// <summary>
        /// Returns new <see cref="ICredentials"/> based on given UserName and Password.
        /// </summary>
        public static ICredentials GetCredentials(string userName, string password)
        {
            return new NetworkCredential(userName, password);
        }

        /// <summary>
        /// Prepare and send <see cref="WebRequest"/> and parse <see cref="WebResponse"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="link"> Website link. </param>
        /// <param name="requestFormat"> Format of <see cref="WebRequest"/>. This can be either "xml" or "json". </param>
        /// <param name="responseEncoding"> <see cref="WebRequest"/> encoding. By default it should be <see cref="Encoding.UTF8"/>. </param>
        /// <param name="method"> <see cref="WebRequest"/>'s method. GET, POST, etc. </param>
        /// <param name="timeout"></param>
        /// <param name="credentials"></param>
        /// <returns></returns>
        public static string GetResponse(string link, string requestFormat, Encoding responseEncoding,
            string method = "GET", int timeout = int.MaxValue, ICredentials credentials = null)
        {
            // Prepare Request
            var request = WebRequest.Create(link);
            request.Method = method; // GET, POST, etc.
            request.ContentType = $"application/{ requestFormat }"; // xml / json
            request.Timeout = timeout;
            request.Credentials = credentials;

            // Prepare Response
            using (var response = request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(stream, responseEncoding))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }
    }
}