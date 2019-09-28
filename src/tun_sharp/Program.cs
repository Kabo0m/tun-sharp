using System;

namespace tun_sharp
{
    using SampSharp.Core;
    using tun_sharp.GameModes;

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
