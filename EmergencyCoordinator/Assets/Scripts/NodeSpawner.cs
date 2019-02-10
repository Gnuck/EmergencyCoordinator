using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeSpawner : MonoBehaviour {

    public static NodeSpawner Instance;

    public GameObject Node;

    public List<GameObject> nodes;

    private static int nodeNumber = 0;
    
	// Use this for initialization
	void Start () {
        Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnNode()
    {
        var newNode = Instantiate(Node, transform.position-new Vector3(0,1.2f,0), Quaternion.Euler(-90,0,0));
        newNode.name = "node" + nodeNumber;
        
        WorldAnchorManager.Instance.AttachAnchor(newNode, newNode.name);
        //PathController pc = GameObject.Find("MixedRealityCamera").GetComponent<PathController>();
        nodeNumber++;
    }
}
