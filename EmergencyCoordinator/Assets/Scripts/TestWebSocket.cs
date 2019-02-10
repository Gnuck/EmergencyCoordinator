#if WINDOWS_UWP
#define CUSTOM_WEBSOCKET
#endif
#if CUSTOM_WEBSOCKET

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Windows.Networking.Sockets;
using System.Threading.Tasks;
using Windows.Web;

using System;	//	System.Uri
using System.IO;

using Windows.System.Threading;

using System.Runtime.InteropServices.WindowsRuntime;	//	AsBuffer
using Windows.Storage.Streams;			// DataWriter
//	https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/WebSocket/cs/Scenario2_Binary.xaml.cs



public class TestWebSocket {

    public TestWebSocket(){}

    public void Start()
    {
        StartAsync();
    }

    async Task StartAsync()
    {

        var socket = new MessageWebSocket();
        socket.MessageReceived += OnMessageReceived;

        try

        {

            await socket.ConnectAsync(TryGetUri("wss://emergency-websocket.herokuapp.com"));
            Debug.Log("opened web socket");
        }

        catch (Exception ex) // For debugging

        {
            Debug.Log("Caught exception connecting to ws");
            socket.Dispose();

            socket = null;


            return;

        }


    }

    static System.Uri TryGetUri(string uriString)

    {

        Uri webSocketUri;

        if (!Uri.TryCreate(uriString.Trim(), UriKind.Absolute, out webSocketUri))
        {
            Debug.Log("Error: Invalid URI");


        }




        // Fragments are not allowed in WebSocket URIs.

        if (!String.IsNullOrEmpty(webSocketUri.Fragment))

            Debug.Log("Error: URI fragments not supported in WebSocket URIs.");



        // Uri.SchemeName returns the canonicalized scheme name so we can use case-sensitive, ordinal string

        // comparison.

        if ((webSocketUri.Scheme != "ws") && (webSocketUri.Scheme != "wss"))
            Debug.Log("Error: WebSockets only support ws:// and wss:// schemes.");


        Debug.Log(webSocketUri);
        return webSocketUri;

    }

    void OnMessageReceived(MessageWebSocket FromSocket, MessageWebSocketMessageReceivedEventArgs InputMessage)

    {

        if (InputMessage.MessageType == SocketMessageType.Utf8)

        {

            var stringLength = InputMessage.GetDataReader().UnconsumedBufferLength;

            string receivedMessage = InputMessage.GetDataReader().ReadString(stringLength);
            Debug.Log("receieved message");
            Debug.Log(receivedMessage);

        }

        else

        {

            //    todo!

            //OutputMessage = new MessageEventArgs( InputMessage.GetDataStream().ReadAsync );

        }

    }
}
#endif