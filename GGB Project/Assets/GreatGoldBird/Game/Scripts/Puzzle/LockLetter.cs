using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AC;

public class LockLetter : MonoBehaviour {

  enum Letter : int {
    A = 0, B = 1, C = 2, D = 3, E = 4,
    F = 5, G = 6, H = 7, I = 8, J = 9,
    K = 10, L = 11, M = 12, N = 13, O = 14,
    P = 15, Q = 16, R = 17, S = 18, T = 19,
    U = 20, V = 21, W = 22, X = 23, Y = 24,
    Z = 25
  }

  [SerializeField] TextMesh[] lockLetters;
  [SerializeField] TextMesh[] lockLettersSmall;
  TextMesh target;
  Vector2 prevPos, nowPos;
  bool isDone;
  string key;

	// Use this for initialization
	void Start () {
    string now = "";
    for (int i = 0; i < lockLetters.Length; i++) {
      now += lockLetters [i].text;
    }
    KickStarter.localVariables.localVars.Find (x => x.label == "Lock Letter Now").SetStringValue (now);
    key = KickStarter.localVariables.localVars.Find (x => x.label == "Lock Letter Key").textVal;
	}
	
	// Update is called once per frame
	void Update () {
    if (isDone)
      return;
    if (Input.GetMouseButtonDown (0)) {
      target = null;
      prevPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
      RaycastHit2D hit = Physics2D.Raycast (prevPos, Vector2.zero);
      if (hit.collider != null) {
        for (int i = 0; i < lockLetters.Length; i++) {
          if (hit.transform.gameObject == lockLetters [i].transform.gameObject)
            target = hit.transform.GetComponent<TextMesh> ();
        }
      }
    } else if (Input.GetMouseButton (0)) {
      if (target == null)
        return;
      nowPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
      float diff = Mathf.Abs (prevPos.y - nowPos.y);
      if (diff >= 1) {
        int letter = (int)System.Enum.Parse (typeof(Letter), target.text);
        if (prevPos.y > nowPos.y) {
          letter++;
          if (letter > 25)
            letter = 0;
        } else if (prevPos.y < nowPos.y) {
          letter--;
          if (letter < 0)
            letter = 25;
        }
        target.text = ((Letter)letter).ToString ();
        for (int i = 0; i < lockLetters.Length; i++) {
          if (target == lockLetters [i]) {
            lockLettersSmall [i].text = target.text;
            break;
          }
        }
        string now = "";
        for (int i = 0; i < lockLetters.Length; i++) {
          now += lockLetters [i].text;
        }
        KickStarter.localVariables.localVars.Find (x => x.label == "Lock Letter Now").SetStringValue (now);
        prevPos = nowPos;
        if (now == key)
          isDone = true;
      }
    } else {
      target = null;
    }
	}
}
