using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyByContact : MonoBehaviour {

	public GameObject explosion;
	public int scoreValue;
	public GameObject playerExplosion;
	private gameController gameController;


	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <gameController>();
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter (Collider other){
		if (other.tag == "Boundary" || other.tag == "Enemy")
		{
			return;
		}

		if (explosion != null)
		{
			Instantiate(explosion, transform.position, transform.rotation);
		}

		if (other.tag == "Player")
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver();
		}

		gameController.AddScore(scoreValue);
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}



