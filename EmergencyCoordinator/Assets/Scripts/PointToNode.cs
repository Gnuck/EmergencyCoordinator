using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToNode : MonoBehaviour {

    public GameObject targetNode;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!(targetNode == null))
        {
            transform.LookAt(targetNode.transform);
        }
	}

    public void AssignTarget(GameObject target)
    {
        targetNode = target;
    }
}
