using Academy;
using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeSpawner : MonoBehaviour {

    public static NodeSpawner Instance;

    public GameObject Node;

    public List<GameObject> nodes;

    private static int nodeNumber = 0;

    private void Awake()
    {
        PlayerPrefs.SetInt("numNode", 0);
        nodeNumber = PlayerPrefs.GetInt("numNodes");
        Debug.Log("node num");
        Debug.Log(nodeNumber);
    }
    // Use this for initialization
    void Start () {
        Instance = this;
        if(nodeNumber > 10)
        {
            Debug.Log("too many nodes");
            Debug.Log(nodeNumber);
            PlayerPrefs.SetInt("numNodes", 0);
            nodeNumber = PlayerPrefs.GetInt("numNodes");
            Debug.Log("after");
            Debug.Log(nodeNumber);
        }
        for (int i = 0; i < nodeNumber ; i++)
        {
            Debug.Log("spawning anchored");
            Debug.Log(i);
            SpawnAnchoredNode(i);
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnNode()
    {
        var newNode = Instantiate(Node, transform.position-new Vector3(0,1.2f,0), Quaternion.Euler(-90,0,0));
        newNode.name = "node" + nodeNumber;

        newNode.AddComponent<NodeInteraction>();
        WorldAnchorManager.Instance.AttachAnchor(newNode, newNode.name);
        SetupManager.Instance.addNode(newNode);
        //PathController pc = GameObject.Find("MixedRealityCamera").GetComponent<PathController>();
        nodeNumber++;

        PlayerPrefs.SetInt("numNodes", nodeNumber);
    }

    public void SpawnAnchoredNode(int num)
    {
        var newNode = Instantiate(Node, transform.position - new Vector3(0, 1.2f, 0), Quaternion.Euler(-90, 0, 0));
        newNode.name = "node" + num;
        Debug.Log("attach anchor");
        newNode.AddComponent<NodeInteraction>();
        WorldAnchorManager.Instance.AttachAnchor(newNode, newNode.name);
        Debug.Log("add to master list");
        SetupManager.Instance.addNode(newNode);
        //PathController pc = GameObject.Find("MixedRealityCamera").GetComponent<PathController>();
    }

    public void resetNodeData()
    {
        nodeNumber = 0;
    }
}
