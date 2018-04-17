using System;
using System.Threading;
using Sequencer.Writers;

namespace Sequencer.Domain
{
    public class Player
    {
        private readonly Arrangement _arrangement;
        private readonly int _bpm;

        public Player(Arrangement arrangement, int bpm)
        {
            _arrangement = arrangement;
            _bpm = bpm;
        }

        public void TranscribeArrangement(IWriter writer)
        {
            var millisecondsPerStep = 60 * 1000 / (_bpm * 4); //4 steps in 1 beat, 4 beats in one bar
            var arrangementStepsNumber = _arrangement.ArrangementStepsNumber;
            var currentStepNumber = 0;
            while (currentStepNumber < arrangementStepsNumber)
            {
                writer.Write("|");
                if (currentStepNumber != 0)
                    Thread.Sleep(millisecondsPerStep);

                writer.Write(_arrangement.TranscribeStep(currentStepNumber));
                currentStepNumber++;
            }
            writer.WriteLine("|");
        }
    }
}