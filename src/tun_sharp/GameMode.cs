using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;

namespace tun_sharp
{
    using System.Timers;
    using SampSharp.GameMode;
    using SampSharp.GameMode.Controllers;
    using SampSharp.GameMode.Events;
    using SampSharp.GameMode.World;

    class GameMode : BaseMode
    {
        private static Timer timer;
        private static List<BasePlayer> players = new List<BasePlayer>();

        private static void OnTimerTick(Object source, ElapsedEventArgs e)
        {
            int id;
            string name, ip;

            Console.WriteLine("Listing Players");

            foreach (BasePlayer player in players)
            {
                id = player.Id;
                ip = player.IP;
                name = player.Name;
                Console.WriteLine($"- {name}({id}) - {ip}");
            }

            Console.WriteLine("");
        }

        #region MySQL methods
        private static void MySQL_OpenConnection()
        {
            string info = "server=localhost;user=root;database=tun;port=3306;password=Camara20";
            MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection(info);
            MySql.Data.MySqlClient.MySqlCommand command;

            try
            {
                Console.WriteLine("MySQL: Connecting to 'tun' database...\n");
                connection.Open();

                // TODO: executing queries here
                command = connection.CreateCommand();
                command.CommandText = "DELETE FROM account";
                command.ExecuteNonQuery();

                Console.WriteLine("MySQL: all 'account' instances were successfully deleted!\n");

                command.CommandText = "INSERT INTO account (username, password) VALUES ('ShaBer', 'qwerty');";
                command.ExecuteNonQuery();
                
                Console.WriteLine("MySQL: 'account' inserted successfully!\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("MySQL: An error occured while atempting to connect to 'tun'");
                Console.WriteLine($"MySQL: - {ex.ToString()}\n");
            }

            connection.Close();
            Console.WriteLine("MySQL: Closing connection");
        }
        #endregion

        #region overrides of BaseModel
        protected override void OnInitialized(EventArgs e)
        {
            Console.WriteLine("\n----------------------------------");
            Console.WriteLine(" The Urban Ninjas");
            Console.WriteLine("----------------------------------\n");

            MySQL_OpenConnection();

            SetGameModeText("Parkour");
            AddPlayerClass(29, new Vector3(1626.472045f, -1682.130859f, 13.375000f), 269.1425f);

            DisableInteriorEnterExits();
            UsePlayerPedAnimations();

            timer = new Timer(1000);
            timer.Elapsed += OnTimerTick;
            //timer.Start();

            base.OnInitialized(e);
        }

        protected override void OnPlayerConnected(BasePlayer player, EventArgs e)
        {
            base.OnPlayerConnected(player, e);

            players.Add(player);
            Console.WriteLine($"{player.Name} has joined the server.");
        }

        protected override void OnPlayerDisconnected(BasePlayer player, DisconnectEventArgs e)
        {
            base.OnPlayerDisconnected(player, e);

            players.Remove(player);
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
