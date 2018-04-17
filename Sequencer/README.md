# SM-808 Implementation (Alexey Solovtsov - alexey.solovtsov@gmail.com)

SM-808 exercise solution is implemented with C# and .NET Core framework.

Program and domain classes are put to Sequencer folder as a part of Sequencer.csproj project
Domain classes tests are put to SequencerTests folder as a part of SequencerTests.csproj project

Tests and console app can be run on Windows using latest Visual Studio 2017 Community, .NET Core 2.1 comes pre-installed in this case.
Otherwise, .NET Core SDK can be installed separately from here https://www.microsoft.com/net/learn/get-started/windows

Also self-contained executable is available for Mac OS X, it's located in Sequencer/Sequencer/bin/Release/netcoreapp2.0/osx-x64/publish
To launch it in terminal, run ```dotnet Sequencer/Sequencer/bin/Release/netcoreapp2.0/osx-x64/publish/Sequencer```
Executable will only run on OS X 10.12 and higher.
