using HoloToolkit.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;


public class VoiceRecognizer : MonoBehaviour
{

    /// <summary>
    /// Allows this class to behave like a singleton
    /// </summary>
    public static VoiceRecognizer Instance;

    /// <summary>
    /// Recognizer class for voice recognition
    /// </summary>
    internal KeywordRecognizer keywordRecognizer;

    /// <summary>
    /// List of coffee Keywords registered
    /// </summary>
    private Dictionary<string, Action> _keywords = new Dictionary<string, Action>();

    /// <summary>
    /// Called on initialization
    /// </summary>
    private void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// Runs at initialization right after Awake method
    /// </summary>
    void Start()
    {
        _keywords.Add("Reset", () =>
        {
            TextToSpeechManager.Instance.ResetCalled();
        });

        _keywords.Add("Test", () =>
        {
            TextToSpeechManager.Instance.OnTest();
        });

        _keywords.Add("Node", () =>
        {
            NodeSpawner.Instance.SpawnNode();
        });

        _keywords.Add("Clear Anchors", () =>
         {
             WorldAnchorManager.Instance.AnchorStore.Clear();
             TextToSpeechManager.Instance.ClearingAnchors();
         });

        //Create the keyword recognizer 
        keywordRecognizer = new KeywordRecognizer(_keywords.Keys.ToArray());

        // Register for the OnPhraseRecognized event 
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        Debug.Log("voice recognizer started");
        keywordRecognizer.Start();
    }

    /// <summary>
    /// Handler called when a word is recognized
    /// </summary>
    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        Action keywordAction;
        // if the keyword recognized is in our dictionary, call that Action.
        if (_keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }
}

