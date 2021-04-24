using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using CommandLine;

namespace ValueSample
{
    [TestFixture]
    public class ValueSample
    {
        [Test]
        public void Value属性サンプル()
        {
            var args = "1st 2nd 3rd 4th x y z".Split( new char[] { ' ' } ).ToArray();

            Parser.Default.ParseArguments<Options>( args )
                .WithParsed( opt =>
                {
                    Assert.That( opt.First, Is.EqualTo( "1st" ) );
                    Assert.That( opt.Second, Is.EqualTo( "2nd" ) );
                    Assert.That( opt.Third, Is.EqualTo( "3rd" ) );
                    Assert.That( opt.Fourth, Is.EqualTo( "4th" ) );
                    Assert.That( opt.Others, Is.EqualTo( new List<string> { "x", "y", "z" } ) );
                } );
        }

        [Test]
        public void Value属性サンプル2()
        {
            var args = "x y z".Split( new char[] { ' ' } ).ToArray();

            Parser.Default.ParseArguments<Options>( args )
                .WithParsed( opt =>
                {
                    Assert.That( opt.First, Is.EqualTo( "x" ) );
                    Assert.That( opt.Second, Is.EqualTo( "y" ) );
                    Assert.That( opt.Third, Is.EqualTo( "z" ) );
                    Assert.That( opt.Fourth, Is.Empty );
                    Assert.That( opt.Others, Is.Null );
                } );
        }

        [Test]
        public void Value属性サンプル3()
        {
            var args = "1st 2nd -e 3rd 4th x y z".Split( new char[] { ' ' } ).ToArray();

            Parser.Default.ParseArguments<Options>( args )
                .WithParsed( opt =>
                {
                    Assert.That( opt.Enabled, Is.True );
                    Assert.That( opt.First, Is.EqualTo( "1st" ) );
                    Assert.That( opt.Second, Is.EqualTo( "2nd" ) );
                    Assert.That( opt.Third, Is.EqualTo( "3rd" ) );
                    Assert.That( opt.Fourth, Is.EqualTo( "4th" ) );
                    Assert.That( opt.Others, Is.EqualTo( new List<string> { "x", "y", "z" } ) );
                } );
        }

        [Test]
        public void Value属性サンプル4()
        {
            // Othersの途中にオプションが含まれていても、全て取得できる
            var args = "1st 2nd 3rd 4th x -e y z".Split( new char[] { ' ' } ).ToArray();

            Parser.Default.ParseArguments<Options>( args )
                .WithParsed( opt =>
                {
                    Assert.That( opt.Enabled, Is.True );
                    Assert.That( opt.First, Is.EqualTo( "1st" ) );
                    Assert.That( opt.Second, Is.EqualTo( "2nd" ) );
                    Assert.That( opt.Third, Is.EqualTo( "3rd" ) );
                    Assert.That( opt.Fourth, Is.EqualTo( "4th" ) );
                    Assert.That( opt.Others, Is.EqualTo( new List<string> { "x", "y", "z" } ) );
                } );
        }
    }
}
