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

    private bool allowMultiClient = true;
    private bool debugMode = true;

    // Keep for now to remember byte format.
    //private struct DataIn
    //{
    //    public DataIn(byte[] buffer)
    //    {
    //        byte nameLength = buffer[0];
    //        this.senderColor = Color.FromArgb(buffer[1], buffer[2], buffer[3]);
    //        this.senderName = Encoding.ASCII.GetString(buffer, 4, nameLength);
    //        this.senderMessage = Encoding.ASCII.GetString(buffer, nameLength + 4, buffer.Length - nameLength - 4);
    //    }

    //    public Color senderColor;
    //    public string senderName;
    //    public string senderMessage;
    //}

    // Probably safe to keep these here.

    #region Initialization/Run
    public void Initialize()
    {
        sSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Console.Title = "Text Server";
        Console.WriteLine("Server initialized.");

        sSock.Bind(groupEP);
        sSock.Listen(4);
        sSock.BeginAccept(new AsyncCallback(OnAccept), sSock);
    }

    // Idle run loop to handle server input.
    public void Run()
    {

    }
    #endregion

    // The Async functions that make everything work.
    #region Async Functions (Accept/Send/Receive)
    private void OnAccept(IAsyncResult ar)
    {

    }

    private void OnSend(IAsyncResult ar)
    {

    }

    private void OnReceive(IAsyncResult ar)
    {

    }
    #endregion


    // Keep these around for now.
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