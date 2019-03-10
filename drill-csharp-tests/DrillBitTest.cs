using NUnit.Framework;
using drill_csharp;

namespace Tests
{
    public class Tests
    {
        const string address = "http://localhost:8047/";

        [SetUp]
        public void Setup()
        {
            // Run Drill docker container with 
            // docker run --rm -d -name drill-1.15.0 -p 8047:8047 -v ~/tmp:/tmp drill/apache-drill:1.15.0 /bin/bash
        }

        [TearDown]
        public void Teardown()
        {
            // Delete running container with 
            // docker rm -f drill-1.15.0
        }

        [Test]
        public void TestSimpleQuery()
        {
            var bit = new DrillBit(address);
            var query = new Query(bit);
            var result = query.Execute("use dfs").Result;
            var summary = result.Rows[0].summary.ToString();
            Assert.AreEqual("Default schema changed to [dfs]", summary);
        }
    }
}