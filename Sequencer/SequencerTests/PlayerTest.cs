using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sequencer.Domain;
using Sequencer.Writers;

namespace SequencerTests
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void player_transcribes_arrangement_correctly_and_in_time()
        {
            var kickPattern =  new Pattern("|X|_|_|_|X|_|_|_|X|_|_|_|X|_|_|_|");
            var snarePattern = new Pattern("|_|_|_|_|X|_|_|_|_|_|_|_|X|_|_|_|");
            var hiHatPattern = new Pattern("|_|_|X|_|_|_|X|_|_|_|X|_|_|_|X|_|");

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
            var player = new Player(arrangement, 120);
            var writer = new StringWriter();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            player.TranscribeArrangement(writer);
            sw.Stop();
            Assert.AreEqual(sw.ElapsedMilliseconds < 2100, true);
            Assert.AreEqual(sw.ElapsedMilliseconds > 1800, true);
            Assert.AreEqual(writer.GetCurrentString(), "|Kick|_|HiHat|_|Kick+Snare|_|HiHat|_|Kick|_|HiHat|_|Kick+Snare|_|HiHat|_|\r\n");
        }
    }
}
