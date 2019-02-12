using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachAnchorToSelf : MonoBehaviour {

	// Use this for initialization
	void Start () {
        AttachWorldAnchor();
    }

    // Update is called once per frame
    void Update () {
    }

    private void AttachWorldAnchor()
    {
        if (WorldAnchorManager.Instance != null)
        {
            // Add world anchor when object placement is done.
            WorldAnchorManager.Instance.AttachAnchor(gameObject,gameObject.name);
        }
    }

    private void RemoveWorldAnchor()
    {
        if (WorldAnchorManager.Instance != null)
        {
            //Removes existing world anchor if any exist.
            WorldAnchorManager.Instance.RemoveAnchor(gameObject);
        }
    }
}
