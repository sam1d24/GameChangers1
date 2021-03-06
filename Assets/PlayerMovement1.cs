using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour {

	public float playerSpeed = 2.0f;
	public float playerJumpPower = 89.0f;
	float jumpLimit = 0;
	bool grounded = false, isDoubleJumped = false;

	// Update is called once per frame
	void Update () 
	{
		Debug.Log ("Hey");
		print (Input.GetAxis("Horizontal"));
		run ();
		if (Input.GetButton ("Jump")) 
		{
//			jumpLimit++;
//			Debug.Log ("jump distance: " + jumpLimit);
//			if (grounded) {
//				//single jump
//				jump ();
//				GetComponent<Animator> ().SetBool ("isJumping", true);
//			} else {
//				if(!isDoubleJumped || (jumpLimit > 100))
//				{
//					jumpLimit = 0;
//					Debug.Log ("double-jumped");
//					isDoubleJumped = true;
//					jump (2);
//				}
//				GetComponent<Animator> ().SetBool ("isJumping", false);
//			}
			GetComponent<Animator> ().SetBool ("isJumping", true);
			jump ();
		} else 
		{
			GetComponent<Animator> ().SetBool ("isJumping", false);
		}
		Debug.Log ("Double jump: " + isDoubleJumped);
	}

	void run()
	{
		if (Input.GetAxis ("Horizontal") != 0)
			GetComponent<Animator> ().SetBool ("isRunning", true);
		else 
			GetComponent<Animator> ().SetBool ("isRunning", false);
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (playerSpeed * Input.GetAxis("Horizontal"), GetComponent<Rigidbody2D>().velocity.y);
	}
		
	void jump()
	{
		float temp_y = 0;
		GetComponent<Rigidbody2D> ().AddForce (Vector2.up * playerJumpPower);
	}

	//for double jumps
	void jump(float dbl)
	{
		GetComponent<Rigidbody2D> ().AddForce (Vector2.up * playerJumpPower * dbl);
	}

	//Collisions from player
	void OnCollisionStay2D(Collision2D col)
	{
		if (col.gameObject.tag == "Ground") 
		{
			grounded = true;
			isDoubleJumped = false;
			jumpLimit = 0;
		}
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Ground") 
		{
			grounded = true;
			isDoubleJumped = false;
			jumpLimit = 0;
		}
	}
	void OnCollisionExit2D(Collision2D col)
	{
		grounded = false;
	}
}
