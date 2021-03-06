﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour
{
    public static PathController Instance;
    public GameObject currentNode = null;
    public GameObject nextnode = null;
    private List<GameObject> followPath = new List<GameObject>();    

    //public List<GameObject> nodeNetwork;

    private static int pathStatus = 0;


    public Material selectedMat;
    public Material pastMat;

    private void Awake()
    {
        if (Instance != null & Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    //Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (pathStatus < followPath.Count && nextnode != null)
        {
            if(Vector3.Distance(transform.position, nextnode.transform.position) < 3.0f)
            {
                pathStatus++;
                if (pathStatus >= followPath.Count)
                {
                    nextnode = null;
                }
                else
                {
                    nextnode = followPath[pathStatus];
                    SetNextNode(followPath[pathStatus]);
                }
            }
        }
    }

    //find the node closest to the HMD/ user
    public GameObject FindClosestNode(List<GameObject> nodeNetwork)
    {
        Debug.Log("closest node in these nodes");
        Debug.Log(nodeNetwork);
        var userPos = transform.position;

        //check if there are node points
        if (nodeNetwork.Count <= 0)
            return null;

        var closestNode = nodeNetwork[0];
        float minDist = Vector3.Distance(closestNode.transform.position, userPos);
        foreach (var node in nodeNetwork)
        {
            float dist = Vector3.Distance(node.transform.position, userPos);
            if (dist < minDist)
            {
                closestNode = node;
                minDist = dist;
            }
        }
        Debug.Log("closest node name");
        Debug.Log(closestNode.name);
        Debug.Log(closestNode.gameObject.name);
        return closestNode;
    }



    public void RouteToNode(GameObject startNode, GameObject endNode)
    {
        string startName = startNode.name;
        //dictionary if distances from the startNode
        Dictionary<string, float> dict = new Dictionary<string, float>();
        dict[startName] = 0.0f;
        List<GameObject> unvisited = new List<GameObject>();
        unvisited.AddRange(startNode.GetComponent<NeighborNodes>().neighbors);
        Debug.Log("hmm");
        //dict[] add to dict
        foreach (GameObject node in unvisited)
        {
            Debug.Log(node.name);
        }
        unvisited.Sort((x,y) => dict[x.name].CompareTo(dict[y.name]));

        Debug.Log("unvisited");
        Debug.Log(unvisited);
        foreach(GameObject node in unvisited)
        {
            Debug.Log(node.name);
            Debug.Log(dict[node.name]);
        }
        //while(unvisited.Count>0)
        //{
        //    GameObject currentNode = unvisited[0];
        //    int i = 0;
        //    foreach (GameObject neighbor in currentNode.GetComponent<NeighborNodes>().neighbors)
        //    {
        //        string neighborName = neighbor.name;
        //        float edgeScore = currentNode.GetComponent<NeighborNodes>().scores[i];
        //        float currentVal = dict[currentNode.name];
        //        float neighborScore = currentVal + edgeScore;

        //        if (dict.ContainsKey(neighborName))
        //        {
        //            if(dict[neighborName] > neighborScore)
        //            {

        //            }
        //            else
        //            {
        //                dict[neighborName] = neighborScore;
        //                neighbor.GetComponent<NeighborNodes>().previous = currentNode;
        //            }
        //        } else
        //        {

        //            dict.Add(neighborName, neighborScore);
        //            neighbor.GetComponent<NeighborNodes>().previous = currentNode;
        //            searchQ.Enqueue(neighbor);
        //        }
        //        i++;
        //    }
        //}
        //GameObject currentNode = unvisitedNodes.Find()
    }

    //greedy implementation of a path search
    public void SearchAllRoutes(GameObject startNode, GameObject endNode)
    {
        //var neighborNodes = startNode.GetComponent<NeighborNodes>();
        //if (neighborNodes.leftNodes.Contains(endNode))
        //    return neighborNodes.leftNodes;
        //else
        //    return neighborNodes.rightNodes;
    }

    //Initialize a new path to guide the user through. 
    public void InitPath(List<GameObject> path)
    {
        pathStatus = 0;
        followPath = path;
        nextnode = followPath[pathStatus];
        var DirectionalIndicator = GameObject.Find("DirectionalIndicator");
        DirectionalIndicator.GetComponent<PointToNode>().AssignTarget(nextnode);
    }

    //Set the next node field and update UI/ visual elements to reflect the change
    void SetNextNode(GameObject next)
    {
        //change current node mat
        nextnode.GetComponent<Renderer>().material = pastMat;
        //update next node and its mat
        nextnode = next;
        nextnode.GetComponent<Renderer>().material = selectedMat;

        var DirectionalIndicator = GameObject.Find("DirectionalIndicator");
        DirectionalIndicator.GetComponent<PointToNode>().AssignTarget(nextnode);
    }

    public GameObject GetNextNode()
    {
        return nextnode;
    }
}
