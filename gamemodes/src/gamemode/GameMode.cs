using System;
using System.Collections.Generic;
using System.Text;

namespace gamemode
{
    using SampSharp.GameMode;
    using SampSharp.GameMode.Controllers;
    using SampSharp.GameMode.World;
    using SampSharp.GameMode.SAMP.Commands;
    
    public class GameMode : BaseMode
    {
        #region Overrides of BaseMode
        protected override void OnInitialized(EventArgs e)
        {
            Console.WriteLine("\n----------------------------------");
            Console.WriteLine(" Blank Gamemode by your name here");
            Console.WriteLine("----------------------------------\n");

            /*
             * TODO: Do your initialisation and loading of data here.
             */

            base.OnInitialized(e);
        }

        protected override void LoadControllers(ControllerCollection controllers)
        {
            base.LoadControllers(controllers);
            /*
             * TODO: Load or unload controllers here.
             */
        }

        [Command("hello", "hi", "hola", "ola", DisplayName = "hello")]
        private static void Hello(BasePlayer player, int msg = 1337)
        {
            switch (msg)
            {
                case 1337:
                    player.SendClientMessage($"Welcome {player.Name}, we hope you're having fun!");
                    break;

                default:
                    player.SendClientMessage($"Welcome, we hope you're having fun!");
                    break; 
            }
            
        }
        #endregion
    }
}
