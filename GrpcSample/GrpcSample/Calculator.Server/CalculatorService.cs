using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Grpc.Core;
using Calculator;

namespace Calculator.Server
{
    class CalculatorService : Calculator.CalculatorBase
    {
        public override Task<CalculatorResponse> Plus( CalculatorRequest request, ServerCallContext context )
        {
            return Task.FromResult( new CalculatorResponse
            {
                Arg1 = request.Arg1,
                Arg2 = request.Arg2,
                Result = request.Arg1 + request.Arg2
            } );
        }

        public override Task<CalculatorResponse> Minus( CalculatorRequest request, ServerCallContext context )
        {
            return Task.FromResult( new CalculatorResponse
            {
                Arg1 = request.Arg1,
                Arg2 = request.Arg2,
                Result = request.Arg1 - request.Arg2
            } );
        }

        public override Task<CalculatorResponse> Multiply( CalculatorRequest request, ServerCallContext context )
        {
            return Task.FromResult( new CalculatorResponse
            {
                Arg1 = request.Arg1,
                Arg2 = request.Arg2,
                Result = request.Arg1 * request.Arg2
            } );
        }

        public override Task<CalculatorResponse> Devide( CalculatorRequest request, ServerCallContext context )
        {
            return Task.FromResult( new CalculatorResponse
            {
                Arg1 = request.Arg1,
                Arg2 = request.Arg2,
                Result = ( request.Arg2 != 0.0 ) ? ( request.Arg1 / request.Arg2 ) : double.NaN
            } );
        }
    }
}
