using System;
using SampSharp.Core;

namespace gamemode
{
    class Program
    {
        static void Main(string[] args)
        {
            new GameModeBuilder()
                .Use<GameMode>()
                .Run();
        }
    }
}
