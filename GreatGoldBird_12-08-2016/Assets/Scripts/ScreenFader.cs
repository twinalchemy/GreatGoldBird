//Author: William Thomas
//Date: 04/12/2016
//Purpose: To create and manage a fader prefab


using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScreenFader : MonoBehaviour {

	public Texture2D aTexture;
	public Color startColor;
	public Color endColor;
	private float fadeTime = 1.5f;
	private float myTimer = 0.0f;

	public delegate void FadeCompleteEvent ();

	private event FadeCompleteEvent OnFadeComplete = null;

	static public void createFade(string _prefabName, FadeCompleteEvent _completeEvent) {

		Object fadePrefab = Resources.Load (_prefabName, typeof(Object));
		GameObject fadeObject = Instantiate(fadePrefab) as GameObject;
		ScreenFader fader = fadeObject.GetComponent<ScreenFader> ();
		fader.OnFadeComplete = _completeEvent;

	}



	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		myTimer += Time.fixedDeltaTime;
		if (myTimer > fadeTime) {
			myTimer = fadeTime;
			if (OnFadeComplete != null) {
				OnFadeComplete ();
				Destroy (gameObject, 0.1f);
			}
		}
	}

	void OnGUI() {
		float percent = myTimer / fadeTime;
		GUI.color = Color.Lerp (startColor, endColor, percent);
		Rect screenRectangle = new Rect (0, 0, Screen.width, Screen.height);
		GUI.DrawTexture (screenRectangle, aTexture);

	}


}
