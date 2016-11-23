//Author: William Thomas
//Date: 05/25/2016
//Purpose: To manage the Tandy-Computer Scene

using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class TwineMgr : MonoBehaviour {
    
    public enum TwineStates {
        OneInitCompData,
        TwoQuote,
        ThreeCrossing,
        FourDozen,
        FiveMouth_Choice1,
        FiveMouth_Choice2,
        FivePending,

        NUM_STATES
    }

    Dictionary<TwineStates, Action> twnStateMachine = new Dictionary<TwineStates, Action>();

    TwineStates currentState;

    [SerializeField]
    private DataObj dataModel;

    [SerializeField]
    private Text clockText;

    [SerializeField]
    private Text dateText;

    [SerializeField]
    private Text innerWindowText;

    [SerializeField]
    private Text directoryData;

    private string curTwinePost;

    [SerializeField]
    private Button bttnOne;

    [SerializeField]
    private Button bttnTwo;

    void SetState(TwineStates nextState) {
        if(currentState != nextState) {
            currentState = nextState;
        }
        print("Twine State Set To: " + currentState);
    }

    enum dayNight {
        AM,
        PM,
        NUMSETS
    }

    void StateOneInitCompData() {

        int curHour = DateTime.Now.Hour;
        int curMin = DateTime.Now.Minute;
        string curTime;
        if (curHour > 12) {
            curHour -= 12;
            curTime = curHour.ToString() + ":" + curMin.ToString() + " " + dayNight.PM.ToString();
        } else {
            curTime = curHour.ToString() + ":" + curMin.ToString() + " " + dayNight.AM.ToString();
        }
        
        clockText.text = curTime;
        dateText.text = DateTime.UtcNow.ToString();

        curTwinePost = "“I will show you fear in a handful of dust.” \n- T.S.Eliot ";
        innerWindowText.text = curTwinePost;

        bttnOne.gameObject.SetActive(false);
        bttnTwo.gameObject.SetActive(false);

        if (Input.GetKeyDown(KeyCode.Space)) {
            SetState(TwineStates.TwoQuote);
        }

    }

    void StateTwo() {
        curTwinePost = "You are crossing a wooded clearing.  The only moisture is the fog of your own breath.  You’ve walked several miles, and your feet ache.  The earth rises up to meet you, instead of giving itself to your weight.  A dark shape grows still. You stop.  Some kind of animal is ahead in the distance.  You’ve seen it many times before, but its name….what is its name….";
        innerWindowText.text = curTwinePost;
        if(Input.GetKeyDown(KeyCode.Space)) {
            SetState(TwineStates.ThreeCrossing);
        }
    }

    void StateThree() {
        curTwinePost = "Nearly a dozen surround you—alert but completely still. The cloud of your breath shrinks to a small stream.  A shape blinks.  You blink.  A shape moves towards you with alarming grace, its massive torso supported by four spindly legs.  Nothing else moves like this… but what is it called?";
        innerWindowText.text = curTwinePost;
        if(Input.GetKeyDown(KeyCode.Space)) {
            SetState(TwineStates.FourDozen);
        }
    }

    void StateFour() {
        curTwinePost = "Your mouth makes the shape of a surprise when you start to say its name out loud.  It stands a few inches from you now.  You reach out your hand to smooth the short, coarse hairs along its jaw.  Its heavy eyelashes blink dreamily.  Steam rolls from its nostrils.  Woodsmoke cuts the air.  In the distance, you see black plumes rising above the treeline.";
        innerWindowText.text = curTwinePost;
        
        string choiceOne = "Follow the horses.";
        BttnSetChoice(bttnOne, true, bttnOne.GetComponentInChildren<Text>(), choiceOne);
        bttnOne.onClick.AddListener( ()=>{BttnS4CA(); });

        string choiceTwo = "Follow the smoke.";
        BttnSetChoice(bttnTwo, true, bttnTwo.GetComponentInChildren<Text>(), choiceTwo);
        bttnOne.onClick.AddListener( () => { BttnS4CB(); });

        SetState(TwineStates.FivePending);

    }

    void StateFivePending() {
        print("Awaiting Choice...");


    }

    void StateFiveA() {
        curTwinePost = "It was only a few firecrackers. I wasn’t trying to burn anything down, I just wanted to see what would happen.  I set them off in the barn, so pa wouldn’t catch me. The first couple didn’t do much, just sparked and whined. So I got bold and threw a handful. The tobacco was the first to catch fire. It spread to the hay and then the horses. They burst from their stalls, and broke towards the woods. I followed them. Sleeping on cold earth for three nights, half-starved, half hoping to die. I woke to the small, tawny mare hovering over me. The one pa said couldn’t be broke. Her breath was warm, her withers charred. I reached for her cautiously, afraid she’d buck if I startled her. But there was no fire left in her eyes. I knew I could go home then. Ain’t nothin left for her here, boy. G’on turn her loose. I let go of her, but she remained perfectly still. Blinking at me dumbly. Maybe she wasn’t broke, just tired. ";
        innerWindowText.text = curTwinePost;

        bttnOne.gameObject.SetActive(false);
        bttnTwo.gameObject.SetActive(false);

    }

    void StateFiveB() {
        curTwinePost = "Wildfire breaks loose, and spooks all the horses.  They tear at the ground, hurtling themselves into the great, dark yawn of Lake Ladoga.  When water is extremely pure—it can stay liquid below the freezing point.  It forgets how to freeze until it has a nucleator— something to freeze around: a snowflake, a fish...a horse.  As the horses swim towards shore, the jaws of the lake snap around them—leaving only their necks suspended above surface.  They remain there all winter, baying at the sky, eyes as milky as the moon. When the ice thaws, the horses sink beneath the surface of the lake.  Fish grow fat on the horses’ flesh.Green tubers sprout from the ashy forest floor.  Deer return.A boy tosses his ball into the lake.He dives to retrieve it, fingers trailing over slimy rocks and weeds.When he surfaces for air, he is holding the jaw of a horse.";
        innerWindowText.text = curTwinePost;

        bttnOne.gameObject.SetActive(false);
        bttnTwo.gameObject.SetActive(false);

    }









    public void BttnSetChoice(Button _bttnObj, bool actvTF, Text _bttnTextObj, string _bttnText) {
        _bttnObj.gameObject.SetActive(actvTF);
        _bttnTextObj.text = _bttnText;
    }

    public void BttnS4CA() {
        print("Clicked Button!");
        SetState(TwineStates.FiveMouth_Choice1);
    }

    public void BttnS4CB() {
        print("Clicked Button!");
        SetState(TwineStates.FiveMouth_Choice2);
    }

    public void CloseBttn() {
        //Should it be a desktop window w/ executable applications?
            //If so then close currently running app and return to desktop
        SceneManager.LoadScene("01_Bedroom");

    }

    public void BttnRefresh() {
        SceneManager.LoadScene("01_BedroomTwine");
    }

    public void LoadBedroom() {
        SceneManager.LoadScene("01_Bedroom");
    }

	// Use this for initialization
	void Start () {
        twnStateMachine.Add(TwineStates.OneInitCompData, StateOneInitCompData);
        twnStateMachine.Add(TwineStates.TwoQuote, StateTwo);
        twnStateMachine.Add(TwineStates.ThreeCrossing, StateThree);
        twnStateMachine.Add(TwineStates.FourDozen, StateFour);
        twnStateMachine.Add(TwineStates.FivePending, StateFivePending);
        twnStateMachine.Add(TwineStates.FiveMouth_Choice1, StateFiveA);
        twnStateMachine.Add(TwineStates.FiveMouth_Choice2, StateFiveB);



        //Initiate Twine
        SetState(TwineStates.OneInitCompData);

        GameObject.Find("Exit/Close").GetComponent<Button>().onClick.AddListener( () => { BttnRefresh(); });

    }

    // Update is called once per frame
    void Update () {
        twnStateMachine[currentState].Invoke();

	}
    
}
