using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sequencer.Domain;

namespace SequencerTests
{
    [TestClass]
    public class ArrangementTest
    {
        [TestMethod]
        public void arrangement_transcribing_steps_with_its_tracks()
        {
            var p1 = new Pattern("|X|_|_|_|X|_|");
            var t1 = new Track(p1, new Sound("Kick"));
            var p2 = new Pattern("|_|_|_|_|X|_|X|_|");
            var t2 = new Track(p2, new Sound("Snare"));
            var tracks = new List<Track> {t1, t2};
            var a = new Arrangement(tracks);
            Assert.AreEqual(a.TranscribeStep(0), "Kick");
            Assert.AreEqual(a.TranscribeStep(1), "_");
            Assert.AreEqual(a.TranscribeStep(4), "Kick+Snare");
            Assert.AreEqual(a.TranscribeStep(6), "Snare");
            Assert.AreEqual(a.TranscribeStep(100), "_");
        }

        [TestMethod]
        public void arrangement_has_steps_number_of_longest_pattern()
        {
            var p1 = new Pattern("|X|_|_|_|X|_|");
            var t1 = new Track(p1, new Sound("Kick"));
            var p2 = new Pattern("|_|_|_|_|X|_|X|_|");
            var t2 = new Track(p2, new Sound("Snare"));
            var tracks = new List<Track> {t1, t2};
            var a = new Arrangement(tracks);
            Assert.AreEqual(a.ArrangementStepsNumber, 8);
        }
    }
}