using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Grpc.Core;
using ServerStreamingRpc;

namespace ServerStreamingRpc.Client
{
    public class FooServiceClient
    {
        public FooServiceClient( FooService.FooServiceClient client )
        {
            _client = client;
        }

        private FooService.FooServiceClient _client = null;

        public async Task<List<int>> GetFooList( int value )
        {
            var ret = new List<int>();

            var req = new FooRequest { Value = value };
            using ( var call = _client.GetFooList( req ) )
            {
                IAsyncStreamReader<FooResponse> resstream = call.ResponseStream;
                while ( await resstream.MoveNext() )
                {
                    var res = resstream.Current;
                    ret.Add( res.Value );
                }
            }

            return ret;
        }
    }
}
