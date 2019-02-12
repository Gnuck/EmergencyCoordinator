#if WINDOWS_UWP
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp2;
using UnityEngine.UI;
public class Socket : MonoBehaviour
{

    private WebSocket ws;
    private void Start()
    {
        ws = new WebSocket("ws://emergency-websocket.herokuapp.com");

        ws.OnOpen += (sender, e) => {
            Debug.Log("Socket::OnOpen -- Connected to websocket");
            ws.Send("string");
        };

        ws.OnMessage += (sender, e) => {
          Debug.Log("Socket::OnMessage -- Got message");
          Debug.Log(e.Data);

        };

        ws.ConnectAsync();
    }

    private void OnApplicationQuit()
    {
        ws.Close();
    }

    public void Send(string message)
    {

        ws.Send(message);
    }

}
#endif
