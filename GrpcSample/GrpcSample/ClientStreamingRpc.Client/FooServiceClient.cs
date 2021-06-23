using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Grpc.Core;

namespace ClientStreamingRpc.Client
{
    class FooServiceClient
    {
        public FooServiceClient( FooService.FooServiceClient client )
        {
            _client = client;
        }

        private FooService.FooServiceClient _client = null;

        public async Task<FooResponse> Total( IEnumerable<FooRequest> requests )
        {
            FooResponse response = null;

            using ( var call = _client.Total() )
            {
                foreach ( var req in requests )
                {
                    await call.RequestStream.WriteAsync( req );
                }
                await call.RequestStream.CompleteAsync();

                response = await call.ResponseAsync;
            }

            return response;
        }
    }
}
