//Author: William Thomas
//Date: 02/28/2016
//Purpose: To manage David's movement and 
//Data specific to the physical player object


using UnityEngine;
using System.IO;
using System.Collections;

public class PlayerController : MonoBehaviour {

    //Global Variables----------------------------------------------------------------------------------------------
    public float Speed = 1f;
    public float Size = 0.01f;
	private string userDescript = "This is me!";
	public string Descript() {
		return userDescript;
	}
    [SerializeField]
    private DataObj myDataModel;

    //Functions-----------------------------------------------------------------------------------------------------
    // Use this for initialization
    void Start () {
        if(FindObjectOfType<DataObj>() != null) {
            myDataModel = FindObjectOfType<DataObj>().GetComponent<DataObj>();
        } else {
            myDataModel = null;
            print("myDataModel is null...");
        }

	}
	// Update is called once per frame
	void Update () {
        Movement();
	}


    //Handle Player Movement--------------------------------------------------------------------------------------------------------
    void Movement() {
        //if the game is ticking
        if (myDataModel.isTicking == true) {

            if(Input.GetKey(KeyCode.Mouse0)) {
                Vector3 tarPos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                              Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
                                               transform.position.z);
                gameObject.GetComponent<Transform>().position = Vector3.Lerp(transform.position, tarPos, Time.deltaTime);
            }
            
            myDataModel.UpdatePlayerPos();

        }
     
    }

}
