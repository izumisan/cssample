using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Xml;
using Newtonsoft.Json;
using NUnit.Framework;

namespace XmlToJsonTest
{
    [TestFixture]
    public class XmlToJsonTest
    {
        [Test]
        public void XMLをJSONに変換する()
        {
            var testfile = Path.Combine( TestContext.CurrentContext.TestDirectory, "testdata", "foo.xml" );
            Assert.That( testfile, Does.Exist );

            var outfile = Path.Combine( TestContext.CurrentContext.TestDirectory, "out_foo.json" );
            if ( File.Exists( outfile ) )
            {
                File.Delete( outfile );
            }
            Assert.That( outfile, Does.Not.Exist );


            var xmldoc = new XmlDocument();
            var xmlcontents = File.ReadAllText( testfile );
            xmldoc.LoadXml( xmlcontents );

            // JsonConvert.SerializeXmlNode()にXmlDocumentオブジェクトを渡せば、
            // XMLをJsonフォーマットに変換できる
            var jsoncontents = JsonConvert.SerializeXmlNode( xmldoc, Newtonsoft.Json.Formatting.Indented );

            File.WriteAllText( outfile, jsoncontents );
            Assert.That( outfile, Does.Exist );
        }
    }
}
