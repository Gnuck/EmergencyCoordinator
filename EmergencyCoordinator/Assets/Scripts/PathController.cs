using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour {

    public GameObject currentNode;
    public GameObject nextnode;

    public List<GameObject> nodeNetwork;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //Returns the closest game object(respresenting a node) to the user
    public GameObject FindClosestNode()
    {
        var userPos = transform.position;

        //check if there are node points
        if (nodeNetwork.Count <= 0)
            return null;

        var closestNode = nodeNetwork[0];
        float minDist = Vector3.Distance(closestNode.transform.position, userPos);
        foreach( var node in nodeNetwork)
        {
            float dist = Vector3.Distance(node.transform.position, userPos);
            if (dist < minDist)
            {
                closestNode = node;
                minDist = dist;
            }
        }

        return closestNode;
    }

 

    //Given two nodes A and B, find the quickest path between them
    void RouteToNode(GameObject startNode, GameObject destNode)
    {
        //create dictionary for every  node, setting values to infinity except startnode (0)

        //get neighbors
    }

}
