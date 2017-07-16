using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class adviewer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		Advertisement.Initialize ("1311696", false);
		StartCoroutine (ShowAdWhenReady ());
	}
	IEnumerator ShowAdWhenReady(){
		while (!Advertisement.IsReady ())
			yield return null;
		Advertisement.Show ();

	}
}