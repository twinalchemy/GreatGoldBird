//Author: William Thomas
//Date: 05/13/16
//Purpose: To create a data model for a button 
//  to exit the game and return to the main menu

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ExitScript : MonoBehaviour {

    public void ReturnToMenu() {
        SceneManager.LoadScene("00_Menu");

    }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



}
