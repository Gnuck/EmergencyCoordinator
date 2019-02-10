using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : Singleton<GameManager> {

	public void Start() {

	}

	public void Send() {
		GetComponent<Socket>().Send("its fuckin treway");
	}

	public void Update() {
		//Debug.Log(MicInput.MicLoudness);
	}


}
