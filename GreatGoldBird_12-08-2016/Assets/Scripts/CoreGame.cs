using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreGame : MonoBehaviour {


    public int curView;

    public Transform View1_Bedroom;
    public Transform View2_Kitchen;

    public bool isBedroom;

    public Transform View3_Lobby;

    public GameObject Inventory;
    public GameObject DevConsole;

    public GameObject Mailbox;



	// Use this for initialization
	void Start () {
        Camera.main.GetComponent<Transform>().SetParent(View1_Bedroom);
        isBedroom = true;
        curView = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.LeftShift) || 
            Input.GetKeyDown(KeyCode.RightShift) || 

            (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.RightShift))) {

                if(curView == 0) {
                    Vector3 newPos = new Vector3(View2_Kitchen.transform.position.x,
                                                    View2_Kitchen.transform.position.y,
                                                    View2_Kitchen.transform.position.z - 10f);
                    Camera.main.transform.position = newPos;
                    curView = 1;
                } else if(curView == 1) {
                    Vector3 newPos = new Vector3(View1_Bedroom.transform.position.x,
                                                        View1_Bedroom.transform.position.y,
                                                        View1_Bedroom.transform.position.z - 10f);
                    Camera.main.transform.position = newPos;
                    curView = 0;
                }
            }

        }
	






}
