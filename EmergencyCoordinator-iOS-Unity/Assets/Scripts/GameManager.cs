using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : Singleton<GameManager> {

	[SerializeField] Text debug;

	public void Start() {

	}

	public void Send() {
		GetComponent<Socket>().Send("asdfasd");
	}

	public void Update() {

		var loudness = MicInput.MicLoudness;
		Debug.Log(loudness);
		debug.text = string.Format("{0}", loudness);
		if (loudness < 0.00005)
		{

			debug.text += "\nHIGH";

		}
		else if (loudness < .005)
		{

			debug.text += "\nMedium";

		}
		else if (loudness > .005) {

			debug.text += "\nLow";

		}



	}


}
