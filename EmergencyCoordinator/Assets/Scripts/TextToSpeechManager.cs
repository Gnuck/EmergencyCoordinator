using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;
using System;

public class TextToSpeechManager : MonoBehaviour
{
    /// <summary>
    /// Allows this class to behave like a singleton
    /// </summary>
    public static TextToSpeechManager Instance;

    private TextToSpeech textToSpeech;

    public string speakText;

    private void Awake()
    {
        Instance = this;

        textToSpeech = GetComponent<TextToSpeech>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTest()
    {
        string speakText = "test voice recognition ";
        //Create message
        var msg = string.Format(
            speakText, textToSpeech.Voice.ToString());

        //speak message
        textToSpeech.StartSpeaking(msg);
    }

    internal void ResetCalled()
    {
        string speakText = "Reset Called";
        //Create message
        var msg = string.Format(
            speakText, textToSpeech.Voice.ToString());

        //speak message
        textToSpeech.StartSpeaking(msg);
    }

    internal void SayPhrase(string name)
    {
        string speakText = name;
        //Create message
        var msg = string.Format(
            speakText, textToSpeech.Voice.ToString());

        //speak message
        textToSpeech.StartSpeaking(msg);
    }

    internal void WaitingToProcessMesh()
    {
        string speakText = "Generating planes, reprocess in five seconds";
        //Create message
        var msg = string.Format(
            speakText, textToSpeech.Voice.ToString());

        //speak message
        textToSpeech.StartSpeaking(msg);
    }


}
