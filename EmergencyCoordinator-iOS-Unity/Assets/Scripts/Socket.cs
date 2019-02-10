using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public class Socket : MonoBehaviour {

	private WebSocket ws;

	private void Start () {
		ws = new WebSocket ("ws://emergency-websocket.herokuapp.com");

		ws.OnOpen += (sender, e) => {
	    Debug.Log("Connected to websocket");
	  };

		ws.OnMessage += (sender, e) => {
			Debug.Log(e.Data);
		};

	  ws.Connect ();
	}

	private void OnApplicationQuit()
	{
		ws.Close();
	}

	public void Send(string message) {

			ws.Send(message);
	}

}
