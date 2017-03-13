// Some of these can be removed.
using System;
using System.Net;
using System.Net.Sockets;
using System.Drawing;
using System.Text;
using System.Collections;
using System.Collections.Generic;
//using System.Threading;
using System.Threading.Tasks;

public class TextServer
{
    // Giant mess of globals because I'm bad at programming.
    private const int listenPort = 7200;
    static IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);
    Socket sSock;

    byte[] buffer;
    static ArrayList clientList;
    private string msgOfTheDay = "« Welcome to PanChat! »";
    private bool allowMultiClient = true;
    private bool debugMode = true;
    private struct ClientInfo
    {
        public Socket socket;
        public string userName;
        public bool isAdmin;
        public string ip;
    }
    private struct DataIn
    {
        public DataIn(byte[] buffer)
        {
            byte nameLength = buffer[0];
            this.senderColor = Color.FromArgb(buffer[1], buffer[2], buffer[3]);
            this.senderName = Encoding.ASCII.GetString(buffer, 4, nameLength);
            this.senderMessage = Encoding.ASCII.GetString(buffer, nameLength + 4, buffer.Length - nameLength - 4);
        }

        public Color senderColor;
        public string senderName;
        public string senderMessage;
    }

    // Initialize() and Run().
    #region Initialization/Run
    public void Initialize()
    {
        sSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Console.Title = "Text Server";
        Console.WriteLine("Server initialized.");    
        buffer = new byte[1024];
        clientList = new ArrayList();
        sSock.Bind(groupEP);
        sSock.Listen(4);
        sSock.BeginAccept(new AsyncCallback(OnAccept), null);
    }

    // Run() needs to have the server commands refactored out.
    public void Run()
    {
        bool done = false;
        string command = "";
        string param1 = "";
        
        while (!done)
        {
            string inputString = Console.ReadLine();
            command = inputString.Split(' ')[0];
            // Currently doesn't allow strings.
            param1 = inputString.Split(' ')[1];

            // Check the command!
            if (command == "exit")
            {
                sendMessage("/kick Server shutting down.");
                done = true;
            }
            else if (command == "debug")
            {
                debugMode = !debugMode;
                if (debugMode)
                    Console.WriteLine("Debug Mode ON");
                else
                    Console.WriteLine("Debug Mode OFF");
            }
            else if (command == "motd")
            {
                msgOfTheDay = "« " + param1 + " »";
                Console.WriteLine("MotD Set To: " + msgOfTheDay);
            }
            else
                Console.WriteLine("Unrecognized command.");
        }
    }
    #endregion

    // The Async functions that make everything work.
    // OnReceive is a huge mess. Several problems with mixing up user endpoints somewhere in there. Also needs to have the server commands be moved elsewhere.
    #region Async Functions (Accept/Send/Receive)
    private void OnAccept(IAsyncResult ar)
    {
        Socket cSock = sSock.EndAccept(ar);
        sSock.BeginAccept(new AsyncCallback(OnAccept), null);
        cSock.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(OnReceive), cSock);
    }

    private void OnSend(IAsyncResult ar)
    {
        Socket cSock = (Socket)ar.AsyncState;
        cSock.EndSend(ar);
    }

    private void OnReceive(IAsyncResult ar)
    {
        try
        {
            Socket cSock = (Socket)ar.AsyncState;
            cSock.EndReceive(ar);
            buffer = TrimArray(buffer);

            //The commands the server uses without the user.
            #region Server Commands
            if (Encoding.ASCII.GetString(buffer).Substring(0, 1) == "/")
            {
                string message = Encoding.ASCII.GetString(buffer);
                if (debugMode)
                    Console.WriteLine(message);

                if (message.Substring(0, 6) == "/login")
                {
                    ClientInfo clientInfo = new ClientInfo();
                    clientInfo.socket = cSock;
                    clientInfo.userName = message.Substring(7, message.Length - 7);
                    clientInfo.ip = clientInfo.socket.RemoteEndPoint.ToString();
                    bool UsedName = false;

                    foreach (ClientInfo client in clientList)
                    {
                        if (clientList.Count > 0)
                        {
                            if ((clientInfo.socket).Equals((client.socket)) && !allowMultiClient)
                            {
                                sendDirectMessage("/kick Only 1 client allowed.", clientInfo);
                                UsedName = true;
                                break;
                            }
                            else if (clientInfo.userName == client.userName)
                            {
                                sendDirectMessage("/kick The name use chose is in use, please try a different name.", clientInfo);
                                UsedName = true;
                                break;
                            }
                        }
                        else
                            break;
                    }

                    if (!UsedName)
                    {
                        foreach (ClientInfo client in clientList)
                        {
                            if (clientList.Count > 0)
                                sendDirectMessage("/login " + client.userName, clientInfo);
                            else
                                break;
                        }

                        clientList.Add(clientInfo);

                        sendMessage("/login " + clientInfo.userName);
                        sendMessage("« " + clientInfo.userName + " has logged in! »");
                        sendDirectMessage(msgOfTheDay, clientInfo);
                        Console.WriteLine(clientInfo.userName + "[" + clientInfo.ip + "] has logged in.");
                    }
                }
                else if (message == "/logout")
                {
                    foreach (ClientInfo clientInfo in clientList)
                    {
                        if (clientInfo.socket.Equals(cSock))
                        {
                            sendMessage("« " + clientInfo.userName + " has logged out! »");
                            sendMessage("/logout " + clientInfo.userName);
                            clientList.Remove(clientInfo);
                            Console.WriteLine(clientInfo.userName + "[" + clientInfo.ip + "] has logged out.");
                            break;
                        }
                    }
                }
            }
            #endregion

            //Handle backend things before processing user commands.
            #region Pre-User Commands Processing
            else
            {
                DataIn data = new DataIn(buffer);

                ClientInfo currentClient = new ClientInfo();
                currentClient.userName = data.senderName;
                currentClient.socket = cSock;
                currentClient.isAdmin = false;

                string timestamp = string.Format("[{0:hh:mm:ss}] ", DateTime.Now);
                if (debugMode)
                    Console.WriteLine("[" + currentClient.socket.RemoteEndPoint.ToString() + "]" + timestamp + data.senderName + ": " + data.senderMessage);
                else
                    Console.WriteLine(timestamp + data.senderName + ": " + data.senderMessage);

                int index = 0;
                foreach (ClientInfo clientInfo in clientList)
                {
                    if (clientInfo.socket.Equals(cSock))
                    {
                        currentClient = (ClientInfo)clientList[index];
                        break;
                    }
                    index++;
                }

                bool msgIsCommand = false;
                #endregion

                // User entered commands
                #region User Commands
                if (data.senderMessage.Substring(0, 1) == "/")
                {
                    string command = data.senderMessage.Substring(1, data.senderMessage.Length - 1);
                    int param1Loc = 0;
                    string param1 = "";

                    msgIsCommand = true;

                    // Check for a space to get param1Loc.
                    for (int i = 0; i < data.senderMessage.Length; i++)
                    {
                        if (data.senderMessage[i] == ' ')
                        {
                            param1Loc = i;
                            break;
                        }
                    }

                    // Get param1 if it exists.
                    if (param1Loc > 0)
                    {
                        command = data.senderMessage.Substring(1, param1Loc - 1).ToLower();
                        param1 = data.senderMessage.Substring(param1Loc + 1, data.senderMessage.Length - command.Length - 2);
                    }

                    if (command == "who" || command == "list")
                    {
                        string message = "";
                        index = 0;
                        foreach (ClientInfo clientInfo in clientList)
                        {
                            index++;

                            if (index == clientList.Count)
                            {
                                message += clientInfo.userName;
                                break;
                            }
                            else
                                message += clientInfo.userName + ", ";
                        }

                        sendDirectMessage("Users Online: " + message, currentClient);
                    }
                    else if (command == "rtd")
                    {
                        int maxNum = 7;
                        Random random = new Random();

                        if (param1 != "")
                        {
                            try
                            {
                                maxNum = int.Parse(param1) + 1;
                                if (maxNum <= 1001 && maxNum > 1)
                                {
                                    int num = random.Next(1, maxNum);
                                    sendMessage(currentClient.userName + " rolled a " + (maxNum - 1) + " sided die! [ " + num + " ]");
                                }
                                else if (maxNum >= 1001)
                                    sendDirectMessage("Number too large! (Max is 1000)", currentClient);
                                else
                                    sendDirectMessage("Number too small! (Min is 1)", currentClient);
                            }
                            // Catch non-numbers.
                            catch (FormatException)
                            {
                                sendDirectMessage("Parameter must be a number!", currentClient);
                            }
                            // Catch numbers too big for an int.
                            catch (OverflowException)
                            {
                                sendDirectMessage("Number too large! (Max is 1000)", currentClient);
                            }
                        }
                        else
                        {
                            int num = random.Next(1, maxNum);
                            sendMessage(currentClient.userName + " rolled a dice! [ " + num + " ]");
                        }
                    }
                    else if (command == "motd")
                    {
                        if (param1 != "" && currentClient.isAdmin)
                        {
                            // Set the MOTD.
                            msgOfTheDay = "« " + param1 + " »";
                            sendDirectMessage("MOTD set.", currentClient);
                        }
                        else
                            sendDirectMessage(msgOfTheDay, currentClient);
                    }
                    else if (command == "dtt" && param1 == "")
                    {
                        sendMessage(currentClient.userName + " has done... the thing...");
                    }
                    else if ((command == "admin" && param1 == "derpity") && !currentClient.isAdmin)
                    {
                        Console.WriteLine(currentClient.userName + " logged in as admin!");
                        currentClient.isAdmin = true;
                        //currentClient.userName = "~" + currentClient.userName;
                        index = 0;
                        foreach (ClientInfo client in clientList)
                        {
                            index++;
                            if (currentClient.userName == client.userName)
                            {
                                break;
                            }
                        }

                        clientList[index - 1] = currentClient;
                        sendDirectMessage("/admin", currentClient);
                    }
                    else if (command == "kick" && currentClient.isAdmin)
                    {
                        foreach (ClientInfo client in clientList)
                        {
                            if (client.userName == param1)
                            {
                                sendDirectMessage("/kick Kicked by admin.", client);
                                break;
                            }
                        }
                    }
                    else if (command == "multiclient" && currentClient.isAdmin)
                    {
                        if (param1 == "allow" || param1 == "true")
                            allowMultiClient = true;
                        else if (param1 == "deny" || param1 == "false")
                            allowMultiClient = false;
                        else
                            allowMultiClient = !allowMultiClient;

                        if (allowMultiClient)
                            Console.WriteLine("Now ALLOWING Multiclients");
                        else
                            Console.WriteLine("Now DENYING Multiclients");
                    }
                    else
                        sendDirectMessage("Unrecognized command.", currentClient);
                }
                #endregion

                if (!msgIsCommand)
                    sendMessage(buffer);
            }

            buffer = new byte[1024];

            cSock.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(OnReceive), cSock);
        }
        catch (Exception ex) { }
        
    }
    #endregion

    // Send functions are a mess. Need to refactor into single function.
    #region Send Functions
    private void sendMessage(byte[] msgBuffer)
    {
        foreach (ClientInfo clientInfo in clientList)
        {
            // Send the message to all users.
            try
            {
                clientInfo.socket.BeginSend(msgBuffer, 0, msgBuffer.Length, SocketFlags.None, new AsyncCallback(OnSend), clientInfo.socket);
            }
            catch (Exception ex) { }
        }
    }

    private void sendMessage(string msgToSend)
    {
        // Take a string and feed it to the buffer.
        if (msgToSend.Length > 1)
        {
            buffer = ToByte(msgToSend);
        }

        foreach (ClientInfo clientInfo in clientList)
        {
            // Send the message to all users
            try
            {
                clientInfo.socket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(OnSend), clientInfo.socket);
            }
            catch (Exception ex) { }
        }
    }

    private void sendDirectMessage(string msgToSend, ClientInfo clientInfo)
    {
        byte[] directBuffer = ToByte(msgToSend);

        //Send the message to a specific user.
        try
        {
            clientInfo.socket.BeginSend(directBuffer, 0, directBuffer.Length, SocketFlags.None, new AsyncCallback(OnSend), clientInfo.socket);
        }
        catch (Exception ex) { }
    }
    #endregion

    // These are misc. functions that could probably be redone and shared with the client.
    #region Misc Functions
    private byte[] TrimArray(byte[] byteArray)
    {
            int byteCounter = byteArray.Length - 1;
            while (byteArray[byteCounter] == 0x00)
            {
                byteCounter--;
            }
            byte[] rv = new byte[(byteCounter + 1)];
            for (int byteCounter1 = 0; byteCounter1 < (byteCounter + 1); byteCounter1++)
            {
                rv[byteCounter1] = byteArray[byteCounter1];
            }

            return rv;
    }

    public byte[] ToByte(string message)
    {
        List<byte> result = new List<byte>();

        result.Insert(0, 0);
        result.Insert(0, 0);
        result.Insert(0, 0);
        result.Insert(0, 0);
        result.AddRange(Encoding.GetEncoding(437).GetBytes(message));

        return TrimArray(result.ToArray());
    }
    #endregion
}