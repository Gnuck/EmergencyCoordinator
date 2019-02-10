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

    public GameObject DirectionalIndicator;
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
        _keywords.Add("Reset Hard", () =>
        {
            TextToSpeechManager.Instance.ResetCalled();
        });

        _keywords.Add("Test", () =>
        {
            TextToSpeechManager.Instance.OnTest();
        });

        _keywords.Add("Drop Node", () =>
        {
            NodeSpawner.Instance.SpawnNode();
        });

        _keywords.Add("Clear Anchors", () =>
         {
             WorldAnchorManager.Instance.RemoveAllAnchors();
             TextToSpeechManager.Instance.ClearingAnchors();
             List<GameObject> nodes = GetComponent<PathController>().nodeNetwork;
             foreach(GameObject node in nodes)
             {
                 Destroy(node);
             }
         });

        _keywords.Add("Current Node", () =>
        {
            TextToSpeechManager.Instance.FindingClosestNode();
            GameObject closeNode = GetComponent<PathController>().FindClosestNode();
            DirectionalIndicator.GetComponent<PointToNode>().AssignTarget(closeNode);
        });

        _keywords.Add("Target Node 0", () =>
        {
            var pc = GetComponent<PathController>();
            var closeNode = pc.FindClosestNode();

            var endNode = pc.nodeNetwork.Find(x => x.name =="node0");
            var searchList = pc.SearchAllRoutes(closeNode, endNode);
            pc.InitPath(searchList);
        });

        _keywords.Add("Print something", () =>
        {
            Debug.Log("asdf");
        });


        //Create the keyword recognizer 
        keywordRecognizer = new KeywordRecognizer(_keywords.Keys.ToArray());

        // Register for the OnPhraseRecognized event 
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        //Debug.Log("voice recognizer started");
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

