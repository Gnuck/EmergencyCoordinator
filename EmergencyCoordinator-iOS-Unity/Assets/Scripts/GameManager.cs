using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : Singleton<GameManager> {

	[SerializeField] Text debug;
	[SerializeField] GameObject panel;
	Image panelImg;

	public void Start() {
		panelImg = panel.GetComponent<Image>();
	}

	public void Send() {
		GetComponent<Socket>().Send("asdfasd");
	}

	public void Update() {
		HandleAudio();

	}

	private void HandleAudio() {
		float loudness = MicInput.MicLoudness;
		float min = 3.0f;
		float max = 6.0f;
		var log = (float)Math.Abs(Math.Log10(loudness));
		var val = Clamp(log, min, max);

		var alpha = (val - min)/max;
		panelImg.color = new Color(255,0,0,alpha);
		//Debug.Log(string.Format("{0}, {1}", loudness, alpha));
		/*
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
		*/
	}

	private float Clamp(float val, float min, float max) {
		if (val <= min)
			return min;

		if (val >= max)
			return max;

		return val;
	}


}
