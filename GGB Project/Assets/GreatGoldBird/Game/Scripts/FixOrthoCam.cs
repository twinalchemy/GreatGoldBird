using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FixOrthoCam : MonoBehaviour {
  
  public float horizontalResolution = 1920;

  void Start() {
    float currentAspect = (float) Screen.width / (float) Screen.height;
    this.GetComponent<Camera>().orthographicSize = horizontalResolution / currentAspect / 100;
  }

}
