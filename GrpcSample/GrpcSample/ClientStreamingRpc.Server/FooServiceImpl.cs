using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Grpc.Core;

namespace ClientStreamingRpc.Server
{
    class FooServiceImpl : FooService.FooServiceBase
    {
        public override async Task<FooResponse> Total( IAsyncStreamReader<FooRequest> requestStream, ServerCallContext context )
        {
            int total = 0;
            while ( await requestStream.MoveNext() )
            {
                total += requestStream.Current.Value;
            }
            return new FooResponse { Value = total };
        }
    }
}
