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
            // Copy donuts.json to ~/tmp
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
        public void TestDfsQuery()
        {
            var bit = new DrillBit(address);
            var query = new Query(bit);
            var result = query.Execute("use dfs").Result;
            var summary = result.Rows[0].summary.ToString();
            Assert.AreEqual("Default schema changed to [dfs]", summary);
        }

        [Test]
        public void TestDonutsQuery()
        {
            var bit = new DrillBit(address);
            var query = new Query(bit);
            var result = query.Execute("select * from dfs.`/tmp/donuts.json` where name= \u0027Cake\u0027").Result;

            var id = result.Rows[0].id.ToString();
            Assert.AreEqual("0001", id);
        }
    }
}