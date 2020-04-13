using Newtonsoft.Json;
using SocketIOClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace BlockPartyTools
{
    class ServerInformation
    {
        public string server { get; set; }
    }

    class Connection : IDisposable
    {
        public string Username { get; set; } = "";

        public double RefreshRate { 
            get {
                if (GetBlockPartyServerTimer != null)
                    return GetBlockPartyServerTimer.Interval;

                return 0;
            }
            set
            {
                if (GetBlockPartyServerTimer != null)
                {
                    GetBlockPartyServerTimer.Interval = value;
                }
            }
        }

        private Client Socket { get; set; }

        private Timer GetBlockPartyServerTimer { get; set; }

        private string LastServer { get; set; } = "NONE";

        public Connection(string username, double refreshRate)
        {
            Username = username;

            Socket = new Client("https://api.hivemc.com:8443");

            Socket.Opened += Socket_Opened;
            Socket.Message += Socket_Message;
            Socket.ConnectionRetryAttempt += Socket_ConnectionRetryAttempt;
            Socket.SocketConnectionClosed += Socket_SocketConnectionClosed;
            Socket.Error += Socket_Error;

            Socket.On("connect", event_connect);
            Socket.On("narration", event_narration);
            Socket.On("loadsong", event_loadsong);
            Socket.On("control", event_control);
            Socket.On("endgame", event_endgame);
            Socket.On("color", event_color);

            GetBlockPartyServerTimer = new Timer(refreshRate);
            GetBlockPartyServerTimer.AutoReset = true;
            GetBlockPartyServerTimer.Stop();
        }

        public void Start()
        {
            Debug.WriteLine("\nConnecting...");
            Socket.Connect();
        }

        public bool IsDisposed { get; private set; }
        public event EventHandler OnDisposed;
        public void Dispose()
        {
            if (IsDisposed) return;
            IsDisposed = true;

            if (GetBlockPartyServerTimer != null)
            {
                GetBlockPartyServerTimer.Stop();
            }

            if (Socket != null)
            {
                if (Socket.IsConnected)
                {
                    //Leave server if we're in a server
                    if (LastServer != "NONE")
                    {
                        leave_server(LastServer);
                    }

                    Socket.Close();
                }
            }

            OnDisposed?.Invoke(this, EventArgs.Empty);
        }

        private void Socket_Opened(object sender, EventArgs e)
        {
            Debug.WriteLine("\nConnection opened\nStarting get server loop...");
            GetBlockPartyServerTimer.Elapsed += track_user;
            GetBlockPartyServerTimer.Start();
        }

        private void Socket_Message(object sender, MessageEventArgs e)
        {
            Debug.WriteLine("\nReceived message: " + e.Message);
        }

        private void Socket_ConnectionRetryAttempt(object sender, EventArgs e)
        {
            Debug.WriteLine("\nConnection lost, attempting to reconnect...");
        }

        private void Socket_SocketConnectionClosed(object sender, EventArgs e)
        {
            Debug.WriteLine("\nConnection closed");
            Dispose();
        }

        private void Socket_Error(object sender, ErrorEventArgs e)
        {
            Debug.WriteLine("\nError:\nException:" + e.Exception.ToString() + "\nMessage: " + e.Message);
        }

        public event EventHandler Connected;
        private void event_connect(SocketIOClient.Messages.IMessage message)
        {
            Connected?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler<NarrationData> NarrationTriggered;
        private void event_narration(SocketIOClient.Messages.IMessage message)
        {
            Debug.WriteLine("\nevent_narration:\n" + message.MessageText);
            EventJson<NarrationData> received = JsonConvert.DeserializeObject<EventJson<NarrationData>>(message.Json.ToJsonString());

            //Validate
            if (!received.Validate()) return;

            NarrationData data = received.args[0].data;
            NarrationTriggered?.Invoke(this, data);
        }

        public event EventHandler<LoadSongData> LoadSongTriggered;
        private void event_loadsong(SocketIOClient.Messages.IMessage message)
        {
            Debug.WriteLine("\nevent_loadsong:\n" + message.MessageText);
            EventJson<LoadSongData> received = JsonConvert.DeserializeObject<EventJson<LoadSongData>>(message.Json.ToJsonString());

            //Validate
            if (!received.Validate()) return;

            LoadSongData data = received.args[0].data;
            LoadSongTriggered?.Invoke(this, data);
        }

        public event EventHandler<ControlData> ControlTriggered;
        private void event_control(SocketIOClient.Messages.IMessage message)
        {
            Debug.WriteLine("\nevent_control:\n" + message.MessageText);
            EventJson<ControlData> received = JsonConvert.DeserializeObject<EventJson<ControlData>>(message.Json.ToJsonString());

            //Validate
            if (!received.Validate()) return;

            ControlData data = received.args[0].data;
            ControlTriggered?.Invoke(this, data);
        }

        public event EventHandler<ColorData> ColorTriggered;
        private void event_color(SocketIOClient.Messages.IMessage message)
        {
            Debug.WriteLine("\nevent_color:\n" + message.MessageText);
            EventJson<ColorData> received = JsonConvert.DeserializeObject<EventJson<ColorData>>(message.Json.ToJsonString());

            //Validate
            if (!received.Validate()) return;

            ColorData data = received.args[0].data;
            ColorTriggered?.Invoke(this, data);
        }

        public event EventHandler<EndGameData> EndGameTriggered;
        private void event_endgame(SocketIOClient.Messages.IMessage message)
        {
            Debug.WriteLine("\nevent_endgame:\n" + message.MessageText);
            EventJson<EndGameData> received = JsonConvert.DeserializeObject<EventJson<EndGameData>>(message.Json.ToJsonString());

            //Validate
            if (!received.Validate()) return;

            EndGameData data = received.args[0].data;
            EndGameTriggered?.Invoke(this, data);
        }

        public event EventHandler<string> JoinedServer;
        private void join_server(string sid)
        {
            JoinedServer?.Invoke(this, sid);

            Socket.Emit("joinserver", new ServerInformation { server = sid });
        }

        public event EventHandler<string> LeftServer;
        private void leave_server(string sid)
        {
            if (sid != "NONE")
            {
                LeftServer?.Invoke(this, sid);

                Socket.Emit("leaveserver", new ServerInformation { server = sid });
            }
        }

        private void track_user(object sender, ElapsedEventArgs e)
        {
            string jsonData;
            using (WebClient client = new WebClient())
            {
                jsonData = client.DownloadString("https://hivemc.com/ajax/getblockpartyserver/" + Username);
            }

            ServerInformation data = JsonConvert.DeserializeObject<ServerInformation>(jsonData);

            if (!string.IsNullOrEmpty(data.server))
            {
                if (data.server != LastServer)
                {
                    if (LastServer != "NONE")
                    {
                        leave_server(LastServer);
                    }
                    if (data.server != "NONE")
                    {
                        join_server(data.server);
                    }
                    LastServer = data.server;
                }
            }
        }
    }
}
