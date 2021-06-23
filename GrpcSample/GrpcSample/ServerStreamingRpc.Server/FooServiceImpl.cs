using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Grpc.Core;

namespace ServerStreamingRpc.Server
{
    class FooServiceImpl : FooService.FooServiceBase
    {
        public override async Task GetFooList( FooRequest request, IServerStreamWriter<FooResponse> responseStream, ServerCallContext context )
        {
            for ( int i = 0; i < 5; ++i )
            {
                // リクエストに対するレスポンスは、IServerStreamWriter<T>に書き込む
                await responseStream.WriteAsync( new FooResponse { Value = request.Value + i } );
            }
        }
    }
}
