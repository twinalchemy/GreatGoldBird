//Author: William Thomas
//Date: 11/20/2016
//Purpose: 

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Scrollbar))]
public class ScrollPosition : MonoBehaviour {

    [Range(0f, 1f)]
    public float scrollStart;
    

	// Use this for initialization
	void Start () {
        GetComponent<Scrollbar>().value = scrollStart;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
