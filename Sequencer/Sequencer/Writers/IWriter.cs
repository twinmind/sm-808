﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sequencer.Writers
{
    public interface IWriter
    {
        void Write(string input);
        void WriteLine(string input);
    }
}
