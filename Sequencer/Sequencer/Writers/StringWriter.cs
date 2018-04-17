using System;
using System.Collections.Generic;
using System.Text;

namespace Sequencer.Writers
{
    public class StringWriter : IWriter
    {
        private StringBuilder _stringBuilder = new StringBuilder();

        public void Write(string input)
        {
            _stringBuilder.Append(input);
        }

        public void WriteLine(string input)
        {
            _stringBuilder.AppendLine(input);
        }

        public string GetCurrentString()
        {
            return _stringBuilder.ToString();
        }
    }
}
