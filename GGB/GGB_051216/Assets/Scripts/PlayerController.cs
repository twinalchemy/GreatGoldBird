//Author: William Thomas
//Date: 02/28/2016
//Purpose: To manage David's movement and 
//Data specific to the physical player object


using UnityEngine;
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
        if(myDataModel.isTicking == true) {
            if (Input.GetKey(KeyCode.A))
            {
                transform.position -= new Vector3(Speed * Time.deltaTime, 0f, 0f);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += new Vector3(Speed * Time.deltaTime, 0f, 0f);
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += new Vector3(0f, Speed * Time.deltaTime,
                                                       Speed/10 * Time.deltaTime);
               
                transform.localScale -= new Vector3(Size * Time.deltaTime, Size * Time.deltaTime, 0f);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position -= new Vector3(0f, Speed * Time.deltaTime, 0f);
                transform.localScale += new Vector3(Size * Time.deltaTime, Size * Time.deltaTime, 0f);
            }

            myDataModel.UpdatePlayerPos();

        }
        //////////vvvvvvvvvvvvThis Requires Further Evaluationvvvvvvvvvvvvvvvvvvvvvvvv///////
        else if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || 
                  Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) ) {

            if (myDataModel.isTicking == false) {
                print("Movement currently disabled. Close the menu to unpause");
            }
        }
       

    }

}
