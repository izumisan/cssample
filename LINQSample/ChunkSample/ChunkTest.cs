using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace ChunkSample
{
    [TestFixture]
    public class ChunkTest
    {
        [Test]
        public void GroupByでN個ずつの要素に分割する()
        {
            var source = Enumerable.Range( 0, 10 );  //=> { 0, 1, 2 ... 9 }

            var actual = source
                .Select( ( v, i ) => new { v, i } )
                .GroupBy( x => x.i / 3 )
                .Select( g => g.Select( x => x.v ) );  //=> { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 9 } }

            Assert.That( actual.Count(), Is.EqualTo( 4 ) );
            Assert.That( actual.ElementAt( 0 ).SequenceEqual( new List<int> { 0, 1, 2 } ), Is.True );
            Assert.That( actual.ElementAt( 1 ).SequenceEqual( new List<int> { 3, 4, 5 } ), Is.True );
            Assert.That( actual.ElementAt( 2 ).SequenceEqual( new List<int> { 6, 7, 8 } ), Is.True );
            Assert.That( actual.ElementAt( 3 ).SequenceEqual( new List<int> { 9 } ), Is.True );
        }

        [Test]
        public void ChunkでN個ずつの要素に分割する()
        {
            var source = Enumerable.Range( 0, 10 );  //=> { 0, 1, 2 ... 9 }

            var actual = source.Chunk( 3 );  //=> { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 9 } }

            Assert.That( actual.Count(), Is.EqualTo( 4 ) );
            Assert.That( actual.ElementAt( 0 ).SequenceEqual( new List<int> { 0, 1, 2 } ), Is.True );
            Assert.That( actual.ElementAt( 1 ).SequenceEqual( new List<int> { 3, 4, 5 } ), Is.True );
            Assert.That( actual.ElementAt( 2 ).SequenceEqual( new List<int> { 6, 7, 8 } ), Is.True );
            Assert.That( actual.ElementAt( 3 ).SequenceEqual( new List<int> { 9 } ), Is.True );
        }
    }
}
