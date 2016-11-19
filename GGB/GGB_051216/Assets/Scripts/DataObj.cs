//Author: William Thomas
//Date: 05/06/16
//Purpose: To create and provide a persistently existing 
//  Global Data Model and the primary GameSetup()

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;

public class DataObj : MonoBehaviour {

    //Global Variables----------------------------------------------------------------------------------------------------------
    private int curScene = 0;
    public int CurScene() {
        return curScene;
    }
    private string devCommsText;
    public string DevCommsText() {
        return devCommsText;
    }
    [SerializeField]
    private TextAsset DevCommsData;
	[SerializeField]
    private List<string> curInvList;
    private Vector3 playerPosition;
    private bool isHeadsUp = false;
    public bool isTicking = false;
    [SerializeField]
    private PlayerController curPlayer;
    [SerializeField]
    private GameObject headsUp;
    [SerializeField]
    private GameObject devConsole;
    [SerializeField]
    private Scrollbar devConScroll;
    [SerializeField]
    private GameObject myInventory;
    [SerializeField]
    private GameObject currCanvas;
    [SerializeField]
    private GameObject curCanvasEventSys;
    [SerializeField]
    private Transform invOddsTransform;
    [SerializeField]
    private Transform invEvenTransform;
   
    //Functions-------------------------------------------------------------------------------------------------------------------
    public void UpdateCurScene() {
        curScene = SceneManager.GetActiveScene().buildIndex;
    }
    public void UpdateDevCommsTextSave(string _item) {
        if(GameObject.Find("ConsoleContent") != null) {
            devCommsText += _item;
            print("Current Saved DevComms Text is... " + DevCommsText() );
        } else {
            print("No Console Window Found...");
        }
    }
	public void AddToInv(string _item) {
        //add item data string to inventory list
        curInvList.Add(_item);

    }
    public void UpdatePlayerPos() {
        if(GameObject.FindObjectOfType<PlayerController>() != null) {
            Transform playerTmpTran = GameObject.FindObjectOfType<PlayerController>().GetComponent<Transform>();
            Vector3 tmpVec = new Vector3(Camera.main.WorldToScreenPoint(playerTmpTran.position).x,
                                         Camera.main.WorldToScreenPoint(playerTmpTran.position).y,
                                         Camera.main.WorldToScreenPoint(playerTmpTran.position).z);
            playerPosition = tmpVec;
            //Write player position to data file
        } else {
            print("No Player Found...");
        }
       
    }
    void LoadDevCommsDataFile() {
        print("Attempting to Find DevComms Data File... ");
        try {
            UnityEngine.Object devCommsData = Resources.Load("DevCommsData", typeof(UnityEngine.Object));
            TextAsset tmpDataObj = Instantiate(devCommsData) as TextAsset;
            DevCommsData = tmpDataObj;
        } catch(Exception ex) {
            print("Encountered Error: " + ex.Message);
        } finally {
            if(DevCommsData != null) {
                print("Collected Text Asset: " + DevCommsData.name);
            } else {
                print("Unable to Collect Text Asset of DevCommsData");
            }
        }
    }
    public void UpdateScroller() {
        devConScroll.value = 0f;
    }
    public void SetMenuActive(bool _face) {
        try {
            headsUp.SetActive(_face);
        } catch(Exception ex) {
            print("Error try{headsUp: " + ex.Message);
        }
    }
    public void SetCommsActive(bool _face) {
        devConsole.SetActive(_face);
        if (_face == true) {
            if (devConScroll == null) {
                devConScroll = GameObject.Find("DevConsole").GetComponentInChildren<Scrollbar>();
            } else if (devConScroll != null) {
                print("DevComms Scrollbar Already Set");
            }
            UpdateScroller();
        }
    }
    public void SetInvActive(bool _face) {
        myInventory.SetActive(_face);
    }
    public void FadeDownCompleted() {
        print("Finsihed Fade Down");
    }
    public void openMenu() {
        if (Input.GetKeyDown(KeyCode.E) && isHeadsUp == false) {
            print("Open the menu");
            headsUp.SetActive(true);
            isHeadsUp = true;
            isTicking = false;
        } else if (Input.GetKeyDown(KeyCode.E) && isHeadsUp == true) {
            print("Close the menu");
            headsUp.SetActive(false);
            isHeadsUp = false;
            isTicking = true;
        }
    }
    void openComms() {
        if (devConsole.activeSelf == false && Input.GetKeyDown(KeyCode.Return)) {
            print("Open Comms");
            SetCommsActive(true);
            GameObject.Find("Viewport").GetComponentInChildren<Text>().text += "Description Console: \n";
            UpdateScroller();
            //Save Current Text to DataFile
            UpdateDevCommsTextSave("Description Console: \n");
        } else if (devConsole.activeSelf == true && Input.GetKeyDown(KeyCode.Return)) {
            print("Close Comms");
            devConsole.SetActive(false);
        }
    }
    void openInventory() {
        if (Input.GetKeyDown(KeyCode.I) && myInventory.activeSelf == false) {
            print("Open Inventory");
            SetInvActive(true);
        } else if (Input.GetKeyDown(KeyCode.I) && myInventory.activeSelf == true) {
            print("Close Inventory");
            SetInvActive(false);
        }
    }
    public void handlePlayerError() {
        try {
            if (curPlayer == null) {
                print("handlePlayerError(): Finding Player...");
                if (GameObject.FindObjectOfType<PlayerController>() == null) {
                    print("handlePlayerError(): No Player Available Found");
                } else {
                    curPlayer =
                        FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
                    print("Player Found");
                }
            }
        } catch(ArgumentException ex) {
            print("handlePlayerError() Player David Obj not in current scene;\ncaught ArgumentException is: " + ex.Message);
            curPlayer = null;
        } catch (UnassignedReferenceException ex) {
            print("handlePlayerError() curPlayer not assigned;\ncaught UnassignedReferenceException is: " + ex.Message);
            curPlayer = null;
        } catch (Exception ex) {
            print("handlePlayerError() caught Exception is: " + ex.Message);
            curPlayer = null;
        } finally {
            print("Player error handled.");
        }
    }
    public void ButtonExit() {
        print("Quitting Application");
        Application.Quit();
    }
    void UpdateCanvas() {
        if(currCanvas == null) {
            try {
                currCanvas = GameObject.FindObjectOfType<Canvas>().gameObject;
            } catch(Exception ex) {
                print("Error try{thisCanvas: " + ex.Message);
                UnityEngine.Object canvasPrefab = Resources.Load("Canvas", typeof(UnityEngine.Object));
                currCanvas = Instantiate(canvasPrefab) as GameObject;
            } finally {
                print("Executed try{thisCanvas");
                UpdateHeadsUpObj();
                UpdateDevCommsObj();
                UpdateMyInventoryObj();
            }
        }
        if(curCanvasEventSys == null) {
             try {
                GameObject thisEventSystem = GameObject.Find("EventSystem(Clone)").gameObject;
            } catch(Exception ex) {
                print("Error try{thisEventSystem: " + ex.Message);
                UnityEngine.Object thisES = Resources.Load("EventSystem", typeof(UnityEngine.Object));
                GameObject ThisEveSys = Instantiate(thisES) as GameObject;
            } finally {
                curCanvasEventSys = GameObject.Find("EventSystem(Clone)").gameObject;
                print("Executed try{thisEventSystem");
            }
        }
    }
    void UpdateHeadsUpObj() {
        if(headsUp == null) {
            try {
                headsUp = GameObject.Find("Menu").gameObject;
            } catch(Exception ex) {
                print("Error {try headsUp: " + ex.Message);
            } finally {
                SetMenuActive(false);
            }
        }
    }
    void UpdateDevCommsObj() {
        if(devConsole == null) {
            try {
                devConsole = GameObject.Find("DevConsole").gameObject;
            } catch(Exception ex) {
                print("Error try{devConsole: " + ex.Message);
            } finally {
                SetCommsActive(false);
            }
        }
       
    }
    void UpdateMyInventoryObj() {
        if(myInventory == null) {
            try {
                myInventory = GameObject.Find("InvConsole").gameObject;
            } catch(Exception ex) {
                print("Error try{myInventory: " + ex.Message);
            } finally {
                SetInvActive(false);
            }
        }
    }
    void UpdateCurPlayerObj() {
        handlePlayerError();
    }
    void SetGameTicker(bool _face) {
        isTicking = _face;
        print("isTicking = " + isTicking.ToString() );
    }
    public void AddToActiveInv(string prefabName, string objData) {
        //set inventory to active state
        SetInvActive(true);
        //load obj---------------------------------------------------------------------------------
        UnityEngine.Object myPrefab = Resources.Load(prefabName, typeof(UnityEngine.Object));
        //form GameObject
        GameObject ObjPrefab = Instantiate(myPrefab) as GameObject;
        //add obj data to invList------------------------------------------------------------------
        curInvList.Add(objData);
        //create float for Vector3.down multiplier
        float downDistance = 25f;
        //create float for modulo comparator-----------------------
        float EorO = 2;
        //check InvList.Count to prepare inventory placement-------
        if(curInvList.Count % EorO == 0) {
            //find and set tempInvEvens
            Transform tempInvEvens = GameObject.Find("InventoryEvens").transform;
            //set parent of object
            ObjPrefab.transform.SetParent(tempInvEvens);
            //set position of ObjPrefab
            ObjPrefab.transform.position = tempInvEvens.position;
            //unset parent
            ObjPrefab.transform.SetParent(GameObject.Find("InvContent").transform);
            //move InvEvens downwards x 25f
            tempInvEvens.position += Vector3.down * downDistance;
        } else if(curInvList.Count % EorO == 1) {
            //find and set tempInvOdds
            Transform tempInvOdds = GameObject.Find("InventoryOdds").transform;
            //set parent of object
            ObjPrefab.transform.SetParent(tempInvOdds);
            //set position of ObjPrefab
            ObjPrefab.transform.position = tempInvOdds.position;
            //unset parent
            ObjPrefab.transform.SetParent(GameObject.Find("InvContent").transform);
            //move InvOdds downwards x 25f
            tempInvOdds.position += Vector3.down * downDistance;
        }
        print("Completed AddToActiveInv(), added: " + prefabName);
    }

    public void GameSetup() {
        ScreenFader.createFade("FadeDown", FadeDownCompleted);

        SetGameTicker(true);
        UpdateCurPlayerObj();
        UpdateCanvas();
        LoadDevCommsDataFile();
        UpdateCurScene();
        UpdatePlayerPos();
        

    }
	// Use this for initialization
	void Start () {
        
	}
	// Update is called once per frame
	void Update () { 
		if (CurScene() != 0) {
            openMenu();
            openComms();
            openInventory();
        }
    }
   
}