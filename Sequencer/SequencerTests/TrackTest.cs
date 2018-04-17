using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sequencer.Domain;

namespace SequencerTests
{
    [TestClass]
    public class TrackTest
    {
        [TestMethod]
        public void track_transcribing_step_within_pattern()
        {
            var p = new Pattern("|X|_|_|_|X|_|_|_|");
            var t = new Track(p, new Sound("Kick"));
            Assert.AreEqual(t.TranscribeStep(4), "Kick");
            Assert.AreEqual(t.TranscribeStep(5), "_");
        }

        [TestMethod]
        public void track_transcribing_step_outside_pattern()
        {
            var p = new Pattern("|X|_|_|_|X|_|_|_|");
            var t = new Track(p, new Sound("Kick"));
            Assert.AreEqual(t.TranscribeStep(100), "_");
        }

        [TestMethod]
        public void track_steps_number()
        {
            var p = new Pattern("|X|_|_|_|X|_|_|_|");
            var t = new Track(p, new Sound("Kick"));
            Assert.AreEqual(t.TrackStepsNumber, 8);
        }
    }
}
