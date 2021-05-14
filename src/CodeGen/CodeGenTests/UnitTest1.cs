using CodeGen.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CodeGenTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var apiHelper = new OpenApiHelper(@"c:\temp\keap_swagger.json");
            var tags = apiHelper.GetTagNames();

            foreach (var tag in tags)
            {
            }
        }
    }
}