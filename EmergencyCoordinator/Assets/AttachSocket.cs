using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachSocket : MonoBehaviour {

	// Use this for initialization
	void Awake () {
#if WINDOWS_UWP
        var testWebSocket = new TestWebSocket();
        testWebSocket.Start();
        //gameObject.AddComponent<Socket>();
        //socket.Send("sup");
#endif
    }

    // Update is called once per frame
    void Update () {

	}
}
