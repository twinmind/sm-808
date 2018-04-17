using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sequencer.Domain;

namespace SequencerTests
{
    [TestClass]
    public class PatternTest
    {
        [TestMethod]
        public void pattern_initialize_with_valid_transcription()
        {
            var p = new Pattern("|X|_|_|_|X|_|_|_|");
            Assert.AreEqual(p.Steps[0], true);
            Assert.AreEqual(p.Steps[1], false);
            Assert.AreEqual(p.Steps[2], false);
            Assert.AreEqual(p.Steps[3], false);
            Assert.AreEqual(p.Steps[4], true);
            Assert.AreEqual(p.Steps[1], false);
            Assert.AreEqual(p.Steps[2], false);
            Assert.AreEqual(p.Steps[3], false);
            Assert.AreEqual(p.StepsNumber, 8);
        }

        [TestMethod]
        public void pattern_initialize_with_no_trailing_pipes_throws_exception()
        {
            try
            {
                var p = new Pattern("X|_|_|_|X|_|_|_");
            }
            catch (Exception e)
            {
                Assert.AreEqual("Missing trailing pipes in pattern transcription", e.Message);
            }
        }

        [TestMethod]
        public void pattern_initialize_with_empty_string()
        {
            try
            {
                var p = new Pattern(string.Empty);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Transcription cannot be empty", e.Message);
            }
        }

        [TestMethod]
        public void pattern_initialize_with_empty_transcription_with_trailing_pipes()
        {
            try
            {
                var p = new Pattern("||");
            }
            catch (Exception e)
            {
                Assert.AreEqual("Transcription cannot be empty", e.Message);
            }
        }

        [TestMethod]
        public void pattern_initialize_with_invalid_step_character()
        {
            try
            {
                var p = new Pattern("|O|");
            }
            catch (Exception e)
            {
                Assert.AreEqual("Incorrect value \"O\" on 1 step. Each step should have either '_' or 'X' character", e.Message);
            }
        }
    }
}
