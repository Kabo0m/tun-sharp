using System;
using System.Collections.Generic;
using System.Text;

namespace gamemode
{
    using SampSharp.GameMode;
    using SampSharp.GameMode.Events;
    using SampSharp.GameMode.Controllers;
    using SampSharp.GameMode.World;
    using SampSharp.GameMode.SAMP;
    using SampSharp.GameMode.SAMP.Commands;
    
    public class GameMode : BaseMode
    {
        #region Overrides of BaseMode
        protected override void OnInitialized(EventArgs e)
        {
            Console.WriteLine("\n----------------------------------");
            Console.WriteLine(" The Urban Ninjas by ShaBer");
            Console.WriteLine("----------------------------------\n");

            SetGameModeText("Parkour");
            AddPlayerClass(29, new Vector3(1626.472045f, -1682.130859f, 13.375000f), 269.1425f);

            // create the first 3DTextLabel in the server, to fix future 3DTextLabels ids
            new TextLabel("TUN", new Color(0xFFFFFFFF), new Vector3(0.0f, 0.0f, -100.0f), 0.0f);

            // #REMOVE# - TagName
            SetNameTagDrawDistance(0.0f);
            ShowNameTags(false);
            // #END# - TagName

            DisableInteriorEnterExits();
            UsePlayerPedAnimations();

            base.OnInitialized(e);
        }

        protected override void OnPlayerRequestClass(BasePlayer player, RequestClassEventArgs e)
        {
            Console.WriteLine($"OnPlayerRequestClass: {player.Name}");
            base.OnPlayerRequestClass(player, e);

            if (player.IsNPC)
	        {
		        return;
	        }

            player.SetPositionFindZ(new Vector3(1626.472045f, -1682.130859f)); // important to properly render the screen
            player.CameraPosition = new Vector3(1626.472045f, -1682.130859f, 13.375000f);
            player.SetCameraLookAt(new Vector3(1643.263305f, -1665.203613f, 23.520149f));
        }

        protected override void OnPlayerSpawned(BasePlayer player, SpawnEventArgs e) 
        {
            Console.WriteLine($"OnPlayerSpawned: {player.Name}");
            base.OnPlayerSpawned(player, e);

            player.SetPositionFindZ(new Vector3(1626.472045, -1682.130859));
            player.Angle = 313.740600f;
        }

        protected override void LoadControllers(ControllerCollection controllers)
        {
            base.LoadControllers(controllers);
            /*
             * TODO: Load or unload controllers here.
             */
        }

        [Command("hello", "hi", "hola", "ola", DisplayName = "hello")]
        private static void Hello(BasePlayer player, int msg = 0)
        {
            switch (msg)
            {
                case 1337:
                    player.SendClientMessage($"50rry {player.Name}, 8u7 y0u d0n'7 533m 7h47 f17 f0r 4 1337 y37! :)");
                    break;

                default:
                    player.SendClientMessage($"Welcome {player.Name}, we hope you're having fun!");
                    break; 
            }
            
        }
        #endregion
    }
}
