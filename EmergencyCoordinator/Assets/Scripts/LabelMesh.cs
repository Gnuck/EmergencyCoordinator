using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelMesh : MonoBehaviour {

	// Use this for initialization
	void Start () {
        CreateLabel();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void CreateLabel() {
        //TextMesh text = Instantiate
        var textMesh = GetComponent<TextMesh>();
        textMesh.text = transform.parent.name;
    } 
}
