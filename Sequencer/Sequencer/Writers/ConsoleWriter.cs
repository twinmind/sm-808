using System;
using System.Collections.Generic;
using System.Text;

namespace Sequencer.Writers
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string input)
        {
            Console.Write(input);
        }

        public void WriteLine(string input)
        {
            Console.WriteLine(input);
        }
    }
}
