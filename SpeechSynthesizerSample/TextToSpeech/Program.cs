using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace TextToSpeech
{
    class Program
    {
        static void Main( string[] args )
        {
            var synth = new SpeechSynthesizer();

            if ( args.Count() <= 0 )
            {
                Console.WriteLine( $@"{synth.Voice.Name} is speaking..." );
                synth.Speak( $@"こんにちは。私はHarukaです。" );
                synth.Speak( @"起動引数のテキストをしゃべります。" );
            }
            else
            {
                args.ToList().ForEach( x => synth.Speak( x ) );
            }
        }
    }
}
