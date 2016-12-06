//Author: William Thomas
//Date: 05/30/2016
//Purpose: To create a return to bedroom button

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ClosetReturn : MonoBehaviour {




    void OnGUI() {
        if (GUI.Button(new Rect(Screen.width - 80f, Screen.height - 40f, 
                                80f, 40f), "Return") ) {
            SceneManager.LoadScene("01_Bedroom");
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}





}
