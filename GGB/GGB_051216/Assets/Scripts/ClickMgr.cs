//Author: William Thomas
//Date: 03/25/2016
//Purpose: To create a persistently existing Data Model 
//  to manage what David can click and what he can not


using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ClickMgr : MonoBehaviour {
    
    //Global Variables-----------------------------------------------------------------------------------------------------------

    [SerializeField]
    private Bedroom_Door doorObj;

    [SerializeField]
    private Apartment_Bedroom_Door aptDoorObj;

    [SerializeField]
    private CompDesk compDesk;

    [SerializeField]
    private EDCbox edcBox;

    [SerializeField]
    private EDC_innerbox edcInnerBox;

    [SerializeField]
    private Pants bedrmPants;

    [SerializeField]
    private Stool bedrmStool;

    [SerializeField]
    private Tandy compTandy;

    [SerializeField]
    private Chair compChair;

    [SerializeField]
    private Cat davidsCat;

    [SerializeField]
    private PlayerController davidUser;

    [SerializeField]
    private Speaker aSpeaker;

    [SerializeField]
    private Closet theCloset;

    [SerializeField]
    private MailBox mailBox;

    [SerializeField]
    private PostItNote catNote;

    [SerializeField]
    private DraftingTable draftTable;

    [SerializeField]
    private RecordPlayer recordPlayer;

    [SerializeField]
    private TandyOnDesk tandyOnDesk;

    [SerializeField]
    private DataObj myDataModel;

    //Functions/Return Vars------------------------------------------------------------------------------------------------------------------

    private Collider2D calcClick(Vector2 _pos, float _val) {
        Collider2D[] theColls = Physics2D.OverlapCircleAll(_pos, _val);
        if (theColls.Length == 1) {
            return Physics2D.OverlapCircle(_pos, _val);
        } else if (theColls.Length > 1) {
            print("Index 0 Object Name: " + theColls[0].name);
            return theColls[0];
        } else {
            return null;
        }
    }
    
   public void postDescript(string _text) {
        myDataModel.SetCommsActive(true);
        GameObject.Find("Viewport").GetComponentInChildren<Text>().text += _text + "\n";
		FindObjectOfType<Scrollbar>().value = 0f;
        myDataModel.UpdateDevCommsTextSave(_text + "\n");
    }
    
	public void checkObject() {
		
		Vector2 curPos;
		curPos.x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
		curPos.y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
        
        if (calcClick(curPos, 0.1f) == null) {
            print("No Object Available");
        } else if (calcClick(curPos, 0.1f).GetComponent<Bedroom_Door>() != null) {
            doorObj = calcClick(curPos, 0.1f).GetComponent<Bedroom_Door>();
            print("Object Collected\n" + "Object Name: " + doorObj.name);
            postDescript(doorObj.Descript());
            ScreenFader.createFade("FadeUp", FindObjectOfType<DataObj>().FadeDownCompleted);
            SceneManager.LoadScene("02_Apartment");
        } else if (calcClick(curPos, 0.1f).GetComponent<Apartment_Bedroom_Door>() != null) {
            aptDoorObj = calcClick(curPos, 0.1f).GetComponent<Apartment_Bedroom_Door>();
            print("Object Collected\n" + "Object Name: " + aptDoorObj.name);
//            GameObject.Find("") = ;
            SceneManager.LoadScene("01_Bedroom");
        } else if (calcClick(curPos, 0.1f).GetComponent<CompDesk>() != null) {
            compDesk = calcClick(curPos, 0.1f).GetComponent<CompDesk>();
            print("Object Collected\n" + "Object Name: " + compDesk.name);
            postDescript(compDesk.Descript());
            if(compTandy != null) {
                compDesk.setupTandy();
            }
        } else if (calcClick(curPos, 0.1f).GetComponent<EDCbox>() != null) {
            edcBox = calcClick(curPos, 0.1f).GetComponent<EDCbox>();
            print("Object Collected\n" + "Object Name: " + edcBox.name);
            postDescript(edcBox.Descript());
        } else if (calcClick(curPos, 0.1f).GetComponent<EDC_innerbox>() != null) {
            edcInnerBox = calcClick(curPos, 0.1f).GetComponent<EDC_innerbox>();
            print("Object Collected\n" + "Object Name: " + edcInnerBox.name);
            postDescript(edcInnerBox.Descript());
        } else if (calcClick(curPos, 0.1f).GetComponent<Pants>() != null) {
            bedrmPants = calcClick(curPos, 0.1f).GetComponent<Pants>();
            print("Object Collected\n" + "Object Name: " + bedrmPants.name);
            postDescript(bedrmPants.Descript());
        } else if (calcClick(curPos, 0.1f).GetComponent<Stool>() != null) {
            bedrmStool = calcClick(curPos, 0.1f).GetComponent<Stool>();
            print("Object Collected\n" + "Object Name: " + bedrmStool.name);
            postDescript(bedrmStool.Descript());
        } else if (calcClick(curPos, 0.1f).GetComponent<Tandy>() != null) {
            compTandy = calcClick(curPos, 0.1f).GetComponent<Tandy>();
            print("Object Collected\n" + "Object Name: " + compTandy.name);
            postDescript(compTandy.Descript());
            //Collect to Inventory
            myDataModel.SetInvActive(true);
            compTandy.addToInv();
        } else if (calcClick(curPos, 0.1f).GetComponent<Chair>() != null) {
            compChair = calcClick(curPos, 0.1f).GetComponent<Chair>();
            print("Object Collected\n" + "Object Name: " + compChair.name);
            postDescript(compChair.Descript());
        } else if (calcClick(curPos, 0.1f).GetComponent<Cat>() != null) {
            davidsCat = calcClick(curPos, 0.1f).GetComponent<Cat>();
            print("Object Collected\n" + "Object Name: " + davidsCat.name);
            postDescript(davidsCat.Descript());
        } else if (calcClick(curPos, 0.1f).GetComponent<PlayerController>() != null) {
            davidUser = calcClick(curPos, 0.1f).GetComponent<PlayerController>();
            print("Object Collected\n" + "Object Name: " + davidUser.name);
            postDescript(davidUser.Descript());
        } else if (calcClick(curPos, 0.1f).GetComponent<Speaker>() != null) {
            aSpeaker = calcClick(curPos, 0.1f).GetComponent<Speaker>();
            print("Object Collected\n" + "Object Name: " + aSpeaker.name);
            postDescript(aSpeaker.Descript());
        } else if (calcClick(curPos, 0.1f).GetComponent<Closet>() != null) {
            theCloset = calcClick(curPos, 0.1f).GetComponent<Closet>();
            print("Object Collected\n" + "Object Name: " + theCloset.name);
            postDescript(theCloset.Descript());
            //Load Closet Scene
            SceneManager.LoadScene("01_BedroomCloset");
        } else if (calcClick(curPos, 0.1f).GetComponent<MailBox>() != null) {
            mailBox = calcClick(curPos, 0.1f).GetComponent<MailBox>();
            print("Object Collected\n" + "Object Name: " + mailBox.name);
            postDescript(mailBox.Descript());
        } else if(calcClick(curPos, 0.1f).GetComponent<PostItNote>() != null) {
            catNote = calcClick(curPos, 0.1f).GetComponent<PostItNote>();
            print("Object Collected\n" + "Object Name: " + catNote.name);
            postDescript(catNote.Descript());
            //Collect Post-It Note to Inventory
            catNote.CreatePostItAsset();
        } else if(calcClick(curPos, 0.1f).GetComponent<TandyOnDesk>() != null) {
            tandyOnDesk = calcClick(curPos, 0.1f).GetComponent<TandyOnDesk>();
            print("Object Collected\n" + "Object Name: " + tandyOnDesk.name);
            SceneManager.LoadScene("02_Twine");
        } else if(calcClick(curPos, 0.1f).GetComponent<DraftingTable>() != null) {
            draftTable = calcClick(curPos, 0.1f).GetComponent<DraftingTable>();
            postDescript(draftTable.Descript());
            print("Object Collected\n" + "Object Name: " + draftTable.name);

        } else if(calcClick(curPos, 0.1f).GetComponent<RecordPlayer>() != null) {
            recordPlayer = calcClick(curPos, 0.1f).GetComponent<RecordPlayer>();
            postDescript(recordPlayer.Descript());
            print("Object Collected\n" + "Object Name: " + recordPlayer.name);
        } else {
            print("No Object Available");
        }
        
    }

    void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
        myDataModel = FindObjectOfType<DataObj>().GetComponent<DataObj>();
        gameObject.GetComponent<Transform>().SetParent(myDataModel.transform);
        myDataModel.GameSetup();


    }

	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            //~~~~~~~~~~if click is in bounds?~~~~~~~~~~~~
			checkObject ();
        }
	}



}
