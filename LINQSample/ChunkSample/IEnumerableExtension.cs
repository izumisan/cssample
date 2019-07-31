using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChunkSample
{
    public static class IEnumerableExtension
    {
        /// <summary>
        /// シーケンスの要素を指定した個数ずつグループ化する
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> Chunk<T>( this IEnumerable<T> source, int size )
        {
            while ( source.Any() )
            {
                yield return source.Take( size );
                source = source.Skip( size );
            }
        }
    }
}
