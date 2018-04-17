using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sequencer.Domain;

namespace SequencerTests
{
    [TestClass]
    public class SoundTest
    {
        [TestMethod]
        public void sound_transcription_matches_its_name()
        {
            var s = new Sound("Kick");
            Assert.AreEqual(s.Transcribe(), "Kick");
        }
    }
}
