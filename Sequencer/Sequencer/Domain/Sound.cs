namespace Sequencer.Domain
{
    public class Sound
    {
        private readonly string _soundName;

        public Sound(string soundName)
        {
            _soundName = soundName;
        }

        public string Transcribe()
        {
            return _soundName;
        }
    }
}