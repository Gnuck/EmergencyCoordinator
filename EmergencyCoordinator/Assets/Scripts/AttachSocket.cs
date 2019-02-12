using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachSocket : MonoBehaviour {

#if WINDOWS_UWP
    Socket socket;
#endif
	// Use this for initialization
	void Awake () {
#if WINDOWS_UWP
        //var testWebSocket = new TestWebSocket();
        //testWebSocket.Start();
        socket = gameObject.AddComponent<Socket>();

#endif
    }

    // Update is called once per frame
    void Update () {

    }
}
