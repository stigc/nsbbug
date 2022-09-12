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
            new DirectoryInfo(Directory.GetCurrentDirectory())
                .GetFiles("*.dll")
                .Select(fi => System.Reflection.Assembly.LoadFile(fi.FullName))
                .ToList();

            using var webApplicationFactory = new WebApplicationFactory<Program>();
            using var scope = webApplicationFactory.Services.CreateScope();
        }
    }
}