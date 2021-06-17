using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Grpc.Core;
using Basic;

namespace Basic.Server
{
    /* foo.proto
    syntax = "proto3";
    package basic;

    service FooService
    {
        rpc Foo (FooRequest) returns (FooReply) {}
    }
    message FooRequest
    {
        string value = 1;
    }
    message FooReply
    {
        string value = 1;
    }
    */
    // protoファイルから自動生成された`FooService.FooServiceBase`を継承した
    // サービスクラスを定義し、関数を実装する

    class FooServiceImpl : FooService.FooServiceBase
    {
        public override Task<FooReply> Foo( FooRequest request, ServerCallContext context )
        {
            return Task.FromResult( new FooReply { Value = $"req: { request.Value }, reply: { request.Value.ToLower() }" } );
        }
    }
}
