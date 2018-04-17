namespace Sequencer.Domain
{
    public class Track
    {
        private readonly Pattern _pattern;
        private readonly Sound _sound;

        public Track(Pattern pattern, Sound sound)
        {
            _pattern = pattern;
            _sound = sound;
        }

        public int TrackStepsNumber => _pattern.StepsNumber;

        public string TranscribeStep(int stepNum)
        {
            if (stepNum >= _pattern.StepsNumber)
                return "_";

            return _pattern.Steps[stepNum] ? _sound.Transcribe() : "_";
        }
    }
}