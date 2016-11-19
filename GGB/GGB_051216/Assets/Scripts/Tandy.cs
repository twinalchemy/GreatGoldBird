//Author: William Thomas
//Date: 05/25/2016
//Purpose: To create and manage a class for the 
//  tandy computer to be collected from David's Closet Scene

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Tandy : MonoBehaviour {
    

	private string compDescript = "This is my Tandy DeskMate!";

	public string Descript() {
		return compDescript;
	}

    private string invData = "Tandy";
    public string InvData() {
        return invData;
    }

    private bool tandyAdded = false;

    [SerializeField]
    private DataObj myDataModel;

    public void addToInv() {
        myDataModel.AddToActiveInv("InvComputer", InvData() );
    }
    
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}



}
