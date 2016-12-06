//Author: William Thomas
//Date: 04/12/2016
//Purpose: To create a Data Model for a Start Button

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonStart000 : MonoBehaviour {

    [SerializeField]
    private DataObj myDataModel;

    //An accessible function for creating fadeup
	public void LoadFadeUp() {
		ScreenFader.createFade ("FadeUp", FadeUpCompleted);
	}

	// Use this for initialization
	void Start () {
        myDataModel = FindObjectOfType<DataObj>().GetComponent<DataObj>();
        //Create a fadedown
        ScreenFader.createFade("FadeDown", FadeDownCompleted);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    //A function for closing the fadedown
    void FadeDownCompleted() {
        print("Fade Complete. Starting Game");
    }

    //A function for closing the fadeup
    void FadeUpCompleted() {
        print("Fade Down Completed");
        SceneManager.LoadScene("01_Bedroom");
        print("Loading Bedroom Scene");
        
    }


}
