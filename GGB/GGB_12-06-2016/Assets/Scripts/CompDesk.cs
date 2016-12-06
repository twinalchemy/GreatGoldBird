//Author: William Thomas
//Date: 05/25/2016
//Purpose: To create a class to allow David to 
//  set the Tandy-Computer in David's Inventory into Bedroom Scene

using UnityEngine;
using System;
using System.Collections;

public class CompDesk : MonoBehaviour {

    private UnityEngine.Object tandyPrefab;

    private string deskDescript = "My computer fits quite well here...";

	public string Descript() {
		return deskDescript;
	}

    private bool tandyPlaced;

    public void setupTandy() {
        
        if (!tandyPlaced) {
            try {
                tandyPrefab = Resources.Load("DeskTandy", typeof(UnityEngine.Object));
                Vector3 tandyPos = new Vector3(gameObject.transform.position.x + 0.5f, 
                                                gameObject.transform.position.y + 0.5f);
                GameObject tandyObj = Instantiate(tandyPrefab, 
                                                  tandyPos, 
                                                  Quaternion.identity) as GameObject;
                RectTransform tandyRect = tandyObj.GetComponent<RectTransform>();
                tandyRect.SetParent(GameObject.Find("Canvas").transform);
            } catch (ArgumentException ex) {
                print("!!!Error is: " + ex.Message + "\nTandy not Found, aborting...");
            } finally {
                print("Placed Tandy on Desk");
                tandyPlaced = true;
                Destroy(GameObject.Find("Clickable_Tandy(Clone)").gameObject);
                print("Inventory Tandy Destroyed");
            }
        }
        //if click tandy on desk - load twinescene

    }

	// Use this for initialization
	void Start () {
        tandyPlaced = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
