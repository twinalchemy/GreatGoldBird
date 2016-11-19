//Author: William Thomas
//Date: 05/13/16
//Purpose: To prevent the attached object(s) 
//  being destroyed from loading Scenes

using UnityEngine;
using System.Collections;

public class DDOL : MonoBehaviour {

    void Awake() {
        DontDestroyOnLoad(gameObject);
    }

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	   
	}


}
