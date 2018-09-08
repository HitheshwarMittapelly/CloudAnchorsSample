using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour {
    private Vector3 treeScale;
	// Use this for initialization
	void Start () {
        treeScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            treeScale *= 1.5f;
            transform.localScale = treeScale;
        }
		
	}
}
