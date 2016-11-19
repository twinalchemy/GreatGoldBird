//Author: William Thomas
//Date: 05/12/2016
//Purpose: To manage David's Closet Scene

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class ClosetMgr : MonoBehaviour {

    
    // Use this for initialization
    void Start () {
        ScreenFader.createFade("FadeDown", 
                                FindObjectOfType<DataObj>()
                                .FadeDownCompleted);
    }
	
	// Update is called once per frame
	void Update () {
	
	}



}
