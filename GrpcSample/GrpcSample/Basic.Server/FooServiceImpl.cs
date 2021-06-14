using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Grpc.Core;
using Basic;

namespace Basic.Server
{
    class FooServiceImpl : FooService.FooServiceBase
    {
        public override Task<FooReply> Foo( FooRequest request, ServerCallContext context )
        {
            return Task.FromResult( new FooReply { Value = $"req: { request.Value }, reply: { request.Value.ToLower() }" } );
        }
    }
}
