using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveStuff : MonoBehaviour {

	public float speed;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}
}
