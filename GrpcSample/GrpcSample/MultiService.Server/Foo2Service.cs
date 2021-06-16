using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Grpc.Core;

namespace MultiService.Server
{
    class Foo2Service : Foo2.Foo2Base
    {
        public override Task<FooResponse> Foo( FooRequest request, ServerCallContext context )
        {
            return Task.FromResult( new FooResponse { Value = request.Value + 2 } );
        }
    }
}
