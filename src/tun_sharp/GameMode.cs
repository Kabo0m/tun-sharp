using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;

namespace tun_sharp
{
    using SampSharp.GameMode;
    using SampSharp.GameMode.Controllers;
    using SampSharp.GameMode.Events;
    using SampSharp.GameMode.World;

    class GameMode : BaseMode
    {
        #region overrides of BaseModel
        protected override void OnInitialized(EventArgs e)
        {
            Console.WriteLine("\n----------------------------------");
            Console.WriteLine(" The Urban Ninjas");
            Console.WriteLine("----------------------------------\n");

            SetGameModeText("Parkour");
            AddPlayerClass(29, new Vector3(1626.472045f, -1682.130859f, 13.375000f), 269.1425f);

            DisableInteriorEnterExits();
            UsePlayerPedAnimations();

            base.OnInitialized(e);
        }

        protected override void OnPlayerConnected(BasePlayer player, EventArgs e)
        {
            base.OnPlayerConnected(player, e);

            Console.WriteLine($"{player.Name} has joined the server.");
        }

        protected override void OnPlayerDisconnected(BasePlayer player, DisconnectEventArgs e)
        {
            base.OnPlayerDisconnected(player, e);

            Console.WriteLine($"{player.Name} has exited the server.");
        }

        protected override void OnPlayerRequestClass(BasePlayer player, RequestClassEventArgs e)
        {
            base.OnPlayerRequestClass(player, e);

            if (player.IsNPC)
            {
                return;
            }

            player.Position = new Vector3(1626.472045f, -1682.130859f, 10.0f); // important to properly render the screen
            player.CameraPosition = new Vector3(1626.472045f, -1682.130859f, 13.375000f);
            player.SetCameraLookAt(new Vector3(1643.263305f, -1665.203613f, 23.520149f));

            Console.WriteLine($"{player.Name} has requested class.");
        }

        protected override void OnPlayerSpawned(BasePlayer player, SpawnEventArgs e)
        {
            base.OnPlayerSpawned(player, e);

            player.SetPositionFindZ(new Vector3(1626.472045f, -1682.130859f, 13.375000f));

            Console.WriteLine($"{player.Name} has spawned.");
        }

        protected override void LoadControllers(ControllerCollection controllers)
        {
            base.LoadControllers(controllers);

            /*
             * TODO: Load or unload controllers here.
             */
        }
        #endregion
    }
}
