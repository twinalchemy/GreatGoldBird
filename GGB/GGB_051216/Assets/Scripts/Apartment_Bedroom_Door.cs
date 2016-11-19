//Author: William Thomas
//Date: 05/25/2016
//Purpose: To create a door in David's Apartment Scene to enter David's Bedroom

using UnityEngine;
using System.Collections;

public class Apartment_Bedroom_Door : MonoBehaviour {




	// Use this for initialization
	void Start () {
        ScreenFader.createFade("FadeDown", FindObjectOfType<DataObj>().FadeDownCompleted);

        

    }
	
	// Update is called once per frame
	void Update () {
	
	}



}
