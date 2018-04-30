using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Speech.Synthesis;

namespace SpeechSynthesizerSample
{
    class Program
    {
        static void Main( string[] args )
        {
            var synth = new SpeechSynthesizer();

            foreach ( var elem in synth.GetInstalledVoices() )
            {
                var info = elem.VoiceInfo;

                Console.WriteLine( $@"Name: {info.Name}" );
                Console.WriteLine( $@"Age: {info.Age}" );
                Console.WriteLine( $@"Gender: {info.Gender}" );
                Console.WriteLine( $@"Culture: {info.Culture}" );
                Console.WriteLine( $@"Description: {info.Description}" );
                Console.WriteLine();

                synth.SelectVoice( info.Name );

                synth.Speak( $@"My name is {info.Name}." );
                synth.Speak( $@"私は、{info.Name}です。" );
            }
        }
    }
}
