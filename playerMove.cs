using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class playerMove : MonoBehaviour {

	public float speed;
	public float tilt;
	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	bool currentPlatformAndroid;
	private float nextFire;
	Rigidbody rb;

	void Awake(){
		rb = GetComponent<Rigidbody> ();
		#if UNITY_ANDROID
		currentPlatformAndroid = true;
		#else
		currentPlatformAndroid = false;
		#endif

	}

	void Update (){
		if (currentPlatformAndroid == true) {
			//android specific code
			//	TouchMove();
			AccellerometerMove ();

		} else {


			if (Input.GetButton ("Fire1") && Time.time > nextFire) {
				nextFire = Time.time + fireRate;
				Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
				GetComponent<AudioSource> ().Play ();
			}
		}
	}
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody>().velocity = movement * speed;

		GetComponent<Rigidbody>().position = new Vector3
			(
				Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
				0.0f, 
				Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
			);

		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}
	void AccellerometerMove(){
		//stores x value in mem 
		float z = Input.acceleration.z;

		float x = Input.acceleration.x;
		if (x < -0.01f) {
			MoveLeft ();
		} else if (x > 0.01f) {
			MoveRight ();
		
		} else {
			SetVelocityZero ();
		}

	}

	public void MoveLeft(){
		rb.velocity = new Vector3 (-speed, 0);

	}
	public void MoveRight(){
		rb.velocity = new Vector3 (speed, 0);

	}
	public void SetVelocityZero(){
		rb.velocity = Vector3.zero;

	}


}