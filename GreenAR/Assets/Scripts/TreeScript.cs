using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore.Examples.CloudAnchors;

public class TreeScript : MonoBehaviour {
    private float treeScale;
    private int hitCounter;
    public DatabaseHandlerScript databaseHandler;
    private bool inResolveMode = false;

    private CloudAnchorController cloudAnchorController;

	// Use this for initialization
	void Start () {
        //hitCounter=0;
        //treeScale = 1f;
        cloudAnchorController = GameObject.FindGameObjectWithTag("CloudController").GetComponent<CloudAnchorController>();
        treeScale = 1f;
        if(cloudAnchorController.m_CurrentMode !=CloudAnchorController.ApplicationMode.Hosting){
            if (cloudAnchorController.m_CurrentMode == CloudAnchorController.ApplicationMode.Ready)
                inResolveMode = true;
        }
        //Debug.Log(transform.localScale);
    }
	
	// Update is called once per frame
	void Update () {
        //databaseHandler.G(treeScale, hitCounter);
        if (inResolveMode)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
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

    }
    public float getHitCounter(){
        return hitCounter;
    }
    public float getScale(){
        
        return treeScale;
    }

    public void updateScale()
    {
        
        if (treeScale < 1.5f)
        {
            treeScale *= 1.2f;
            transform.localScale *= treeScale;
            hitCounter++;
        }

    }
}
