//Author: William Thomas
//Date: 05/25/2016
//Purpose: To create a note to be collected to David's inventory

using UnityEngine;
using System;
using System.Collections.Generic;

public class PostItNote : MonoBehaviour {


    private string noteDescript = "Post it Note: CAT = MAIL";

    public string Descript() {
        return noteDescript;
    }

    private string invData;
    public string InvData() {
        return invData;
    }
    private bool postItAdded = false;

    [SerializeField]
    private DataObj myDataModel;
    
    public void CreatePostItAsset() {
        if(postItAdded == false) {
            myDataModel.AddToActiveInv("PostIt", InvData());
            postItAdded = true;
        } else {
            print("Already Aquired PostItAsset");
        }
        
    }
    
    // Use this for initialization
    void Start () {
        invData = "DRENote";
        myDataModel = FindObjectOfType<DataObj>().GetComponent<DataObj>();
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}





}
