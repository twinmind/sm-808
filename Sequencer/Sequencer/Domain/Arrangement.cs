using System.Collections.Generic;

namespace Sequencer.Domain
{
    public class Arrangement
    {
        private readonly List<Track> _tracks;

        public Arrangement(List<Track> tracks)
        {
            _tracks = tracks;
            foreach (var t in _tracks)
                if (t.TrackStepsNumber > ArrangementStepsNumber)
                    ArrangementStepsNumber = t.TrackStepsNumber;
        }

        public int ArrangementStepsNumber { get; }

        public string TranscribeStep(int stepNumber)
        {
            var stepTranscription = "_";
            foreach (var t in _tracks)
            {
                var currentTrackStepTranscription = t.TranscribeStep(stepNumber);
                if (currentTrackStepTranscription == "_") continue;

                if (stepTranscription == "_")
                    stepTranscription = currentTrackStepTranscription;
                else
                    stepTranscription += "+" + currentTrackStepTranscription;
            }

            return stepTranscription;
        }
    }
}