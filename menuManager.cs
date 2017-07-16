using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour {

	public Button[] buttons;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach (Button button in buttons) {
			button.gameObject.SetActive(true);

		}
		
	}
	public void Play(){
		SceneManager.LoadScene ("one");	
	}
	public void Exit(){
		Application.Quit ();

	}
}
