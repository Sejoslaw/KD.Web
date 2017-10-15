using System.Text;
using Xunit;

namespace KD.Web.Tests
{
    public class RequestTests
    {
        [Fact]
        public void Test_Xml_Request()
        {
            var response = Requests.GetResponse("https://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml", "xml", Encoding.UTF8);
            Assert.True(!string.IsNullOrEmpty(response));
        }
    }
}