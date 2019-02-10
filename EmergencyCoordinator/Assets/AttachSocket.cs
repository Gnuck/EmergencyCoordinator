using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachSocket : MonoBehaviour {

	// Use this for initialization
	void Start () {
#if WINDOWS_UWP
        Debug.Log("AttachSocket::Start()");
            gameObject.AddComponent<Socket>();
#endif
    }

    // Update is called once per frame
    void Update () {

	}
}
