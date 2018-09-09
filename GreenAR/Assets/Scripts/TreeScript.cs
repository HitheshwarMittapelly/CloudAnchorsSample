using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour {
    private float treeScale=1f;
    private int hitCounter=1;
    public DatabaseHandlerScript databaseHandler;
	// Use this for initialization
	void Start () {
        //hitCounter=0;
        //treeScale = 1f;
	}
	
	// Update is called once per frame
	void Update () {
        //databaseHandler.G(treeScale, hitCounter);
        if (Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Debug.Log("clicked tree");
            if (treeScale < 1.5f)
                {
                    treeScale *= 1.2f;
                    transform.localScale *= treeScale;
                    hitCounter++;
                }

        }

        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;
        //if(Physics.Raycast(ray,out hit)){
        //    if (hit.transform.name == "Tree")
        //    {
        //        Debug.Log("clicked tree");
        //        if (treeScale < 5f)
        //        {
        //            treeScale *= 1.2f;
        //            transform.localScale *= treeScale;
        //            hitCounter++;
        //        }
        //    }

        //}

    }
    public float getHitCounter(){
        return hitCounter;
    }
    public float getScale(){
        
        return treeScale;
    }
}
