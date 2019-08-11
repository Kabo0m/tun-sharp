using System;

namespace tun_sharp
{
    using SampSharp.Core;

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
