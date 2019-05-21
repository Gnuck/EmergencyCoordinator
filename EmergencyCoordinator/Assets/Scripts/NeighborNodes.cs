using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighborNodes : MonoBehaviour {

    public List<GameObject> neighbors;
    public List<GameObject> visitedNeighbors;
    public List<GameObject> lineList;

    private void Awake()
    {
        neighbors = new List<GameObject>();
        lineList = new List<GameObject>();
        visitedNeighbors = new List<GameObject>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addNeighbor(GameObject node)
    {
        if (!neighbors.Contains(node))
        {
            neighbors.Add(node);
            Debug.Log("added neighbor");
        }
        Debug.Log("neighbor already exists");
    }

    public void ShowNeighbors()
    {
        List<GameObject> nbs = GetComponent<NeighborNodes>().neighbors;

        foreach (GameObject nb in nbs)
        {
            if (visitedNeighbors.Contains(nb))
            {
                //do nothing
            } else
            {
                GameObject line = new GameObject();
                line.transform.position = transform.position + new Vector3(0, 1, 0);
                line.AddComponent<LineRenderer>();
                LineRenderer lr = line.GetComponent<LineRenderer>();
                lr.material.color = Color.cyan;
                lineList.Add(line);
                //line.material = new Material(Shader.Find("Particles/Additive"));
                Debug.Log("about to draw line");
                lr.startWidth = 0.1f;
                lr.endWidth = 0.1f;

                lr.SetPosition(0, transform.position + new Vector3(0, 0.2f, 0));
                lr.SetPosition(1, nb.transform.position + new Vector3(0, 0.2f, 0));
                visitedNeighbors.Add(nb);
                nb.GetComponent<NeighborNodes>().ShowNeighbors();
            }
        }
    }

    public void ShowUnvisitedNeighbors()
    {

    }
}
