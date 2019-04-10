using System.Collections.Generic;
using UnityEngine;

public class SetupManager : MonoBehaviour
{

    public static SetupManager Instance;

    public GameObject selectedNode;
    public List<GameObject> allNodes;
    public Material selectedMaterial;
    public Material networkMaterial;

    private static int nodeNumber = 0;

    private void Awake()
    {
        allNodes = new List<GameObject>();
    }
    // Use this for initialization
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void selectNode(GameObject node)
    {
        selectedNode = node;
        selectedNode.GetComponent<Renderer>().material = selectedMaterial;
    }

    public void addNode(GameObject node)
    {
        allNodes.Add(node);
        node.GetComponent<Renderer>().material = networkMaterial;
    }
}
