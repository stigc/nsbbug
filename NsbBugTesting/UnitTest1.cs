using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.IO;
using System.Linq;

namespace NsbBugTesting
{
    public class Tests
    {
        [Test]
        public void Test()
        {
            var path = Path.GetFullPath("NsbBug.dll");
            //Commmet out this line, and the test is green
            System.Reflection.Assembly.LoadFile(path);

            using var webApplicationFactory = new WebApplicationFactory<Program>();
            using var scope = webApplicationFactory.Services.CreateScope();
        }
    }
}
