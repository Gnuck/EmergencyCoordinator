#if WINDOWS_UWP
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using UnityEngine.UI;
public class Socket : MonoBehaviour
{

    private WebSocket ws;
    public Text socketText;
    private void Start()
    {
        Debug.Log("socket started");
        ws = new WebSocket("ws://emergency-websocket.herokuapp.com");

        ws.OnOpen += (sender, e) => {
            Debug.Log("Connected to websocket");
        };

        ws.OnMessage += (sender, e) => {
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