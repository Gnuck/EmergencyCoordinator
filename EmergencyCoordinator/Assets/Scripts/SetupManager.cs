using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupManager : MonoBehaviour
{

    public static SetupManager Instance;

    public GameObject selectedNode;
    public GameObject destNode;
    public List<GameObject> allNodes;
    public Material selectedMaterial;
    public Material networkMaterial;
    public Material noneMaterial;

    public Button neighborButton;

    public bool selectingNeighbors = false;

    private static int nodeNumber = 0;

    private void Awake()
    {
        allNodes = new List<GameObject>();
        if (Instance != null & Instance != this)
        {
            Destroy(this.gameObject);
        } else
        {
            Instance = this;
        }
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void selectNode(GameObject node)
    {
        if (selectingNeighbors && selectedNode != null)
        {
            Debug.Log("should add neighbors");
            if(node != selectedNode && !selectedNode.GetComponent<NeighborNodes>().neighbors.Contains(node))
            {
                selectedNode.GetComponent<NeighborNodes>().addNeighbor(node);
                node.GetComponent<Renderer>().material = networkMaterial;
            }
            else if(node != selectedNode && selectedNode.GetComponent<NeighborNodes>().neighbors.Contains(node))
            {
                selectedNode.GetComponent<NeighborNodes>().neighbors.Remove(node);
                node.GetComponent<Renderer>().material = noneMaterial;
            }
        } else if (!selectingNeighbors && selectedNode == null) {
            selectedNode = node;
            selectedNode.GetComponent<Renderer>().material = selectedMaterial;
        } else if (selectedNode == node)
        {
            deselectNode(node);
        } else if (selectedNode != null && !selectingNeighbors)
        {
            selectedNode.GetComponent<Renderer>().material = noneMaterial;
            List<GameObject> nbors = selectedNode.GetComponent<NeighborNodes>().neighbors;
            foreach(GameObject nb in nbors)
            {
                nb.GetComponent<Renderer>().material = noneMaterial;
            }
            selectedNode = node;
            selectedNode.GetComponent<Renderer>().material = selectedMaterial;
            List<GameObject> newnbors = selectedNode.GetComponent<NeighborNodes>().neighbors;
            foreach(GameObject nb in newnbors)
            {
                nb.GetComponent<Renderer>().material = networkMaterial;
            }
        }
        else
        {
        }
    }

    private void deselectNode(GameObject node)
    {
        if (selectingNeighbors)
        {
            selectedNode.GetComponent<NeighborNodes>().neighbors.Remove(node);
        } else
        {
            selectedNode.GetComponent<Renderer>().material = noneMaterial;
            selectedNode = null;
        }
    }

    public void neighborMode()
    {
        selectingNeighbors = !selectingNeighbors;
        if (selectingNeighbors)
        {
            neighborButton.GetComponentInChildren<Text>().text = "Select Node";
        } else
        {
            neighborButton.GetComponentInChildren<Text>().text = "Select Neighbors";
        }
    }

    public void addNode(GameObject node)
    {
        Debug.Log("addNode called");
        Debug.Log(node.name);
        allNodes.Add(node);
        node.GetComponent<Renderer>().material = noneMaterial;
    }

    public void showSelectNeighbors()
    {
        selectedNode.GetComponent<NeighborNodes>().ShowNeighbors();
    }

    public void getClosestNode()
    {
        GameObject closestNode = PathController.Instance.FindClosestNode(allNodes);
        selectNode(closestNode);
    }

    public void getRoute(GameObject node)
    {
        destNode = node;
        PathController.Instance.RouteToNode(selectedNode, destNode);
    }
}
