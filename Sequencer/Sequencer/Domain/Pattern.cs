using System;

namespace Sequencer.Domain
{
    public class Pattern
    {
        public Pattern(string transcription)
        {
            if(string.IsNullOrEmpty(transcription) || transcription == "||")
                throw new Exception("Transcription cannot be empty");

            if (transcription[0] != '|' || transcription[transcription.Length - 1] != '|')
                throw new Exception("Missing trailing pipes in pattern transcription");

            transcription = transcription.Substring(1, transcription.Length - 2);

            var transcriptedSteps = transcription.Split('|');
            StepsNumber = transcriptedSteps.Length;
            Steps = new bool[StepsNumber];

            for (var i = 0; i < StepsNumber; i++)
            {
                if (transcriptedSteps[i].Length != 1 || (transcriptedSteps[i] != "_" && transcriptedSteps[i] != "X"))
                    throw new Exception(string.Format(
                        "Incorrect value \"{0}\" on {1} step. Each step should have either '_' or 'X' character",
                        transcriptedSteps[i], i + 1));

                if (transcriptedSteps[i] == "_")
                    Steps[i] = false;
                else if (transcriptedSteps[i] == "X")
                    Steps[i] = true;
            }
        }

        public bool[] Steps { get; }

        public int StepsNumber { get; }
    }
}