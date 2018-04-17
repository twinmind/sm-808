using System;
using System.Collections.Generic;
using Sequencer.Domain;
using Sequencer.Writers;

namespace Sequencer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Drum sounds transcriptions:");
            var kickTranscription =  "|X|_|_|_|X|_|_|_|X|_|_|_|X|_|_|_|";
            var snareTranscription = "|_|_|_|_|X|_|_|_|_|_|_|_|X|_|_|_|";
            var hiHatTranscription = "|_|_|X|_|_|_|X|_|_|_|X|_|_|_|X|_|";

            Console.WriteLine("Kick  -> " + kickTranscription);
            Console.WriteLine("Snare -> " + snareTranscription);
            Console.WriteLine("HiHat -> " + hiHatTranscription);

            var kickPattern = new Pattern(kickTranscription);
            var snarePattern = new Pattern(snareTranscription);
            var hiHatPattern = new Pattern(hiHatTranscription);

            var kickTrack = new Track(kickPattern, new Sound("Kick"));
            var snareTrack = new Track(snarePattern, new Sound("Snare"));
            var hiHatTrack = new Track(hiHatPattern, new Sound("HiHat"));

            var arrangementTracks = new List<Track>
            {
                kickTrack,
                snareTrack,
                hiHatTrack
            };
            var arrangement = new Arrangement(arrangementTracks);

            Console.WriteLine("BPM: 120; Repeat 4 times");
            var player = new Player(arrangement, 120);
            var writer = new ConsoleWriter();

            //Repeat four times
            var time = 0;
            while (time < 4)
            {
                player.TranscribeArrangement(writer);
                time++;
            }

            Console.WriteLine("Sequencer playback transcription completed.");
        }
    }
}