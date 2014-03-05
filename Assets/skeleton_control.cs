using UnityEngine;
using System.Collections;

public class skeleton_control : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	void Flip(int dir){
		Quaternion theRotation;
		switch (dir) {
		case 0:theRotation=Quaternion.AngleAxis(90,Vector3.forward);break;
		case 1:theRotation=Quaternion.AngleAxis(180,Vector3.forward);break;
		case 2:theRotation=Quaternion.AngleAxis(270,Vector3.forward);break;
		case 3:theRotation=Quaternion.AngleAxis(0,Vector3.forward);break;
		default:theRotation=Quaternion.AngleAxis(0,Vector3.forward);break;
		}
			transform.localRotation=theRotation;
	}

	// Update is called once per frame
	void FixedUpdate () {
		Rigidbody2D rg = rigidbody2D;
		float move = Input.GetAxis ("Horizontal");
		//rigidbody2D.velocity = new Vector2 (move*10, 0);
		//rigidbody2D.AddForce (new Vector2 (1000, 0));
		bool key_up = Input.GetKey (KeyCode.W);
		bool key_down = Input.GetKey (KeyCode.S);
		bool key_left = Input.GetKey (KeyCode.A);
		bool key_right = Input.GetKey (KeyCode.D);
		Animator anim = GetComponent<Animator> ();
		anim.SetFloat ("spd", 0);
		if (key_up) {
			rigidbody2D.velocity = new Vector2 (0, 10);
			anim.SetFloat ("spd", 100);
			Flip (1);
		}
		if (key_down) {
			rigidbody2D.velocity = new Vector2 (0, -10);
			anim.SetFloat ("spd", 100);
			Flip (3);
		}
		if (key_left) {
			rigidbody2D.velocity = new Vector2 (-10, 0);
			anim.SetFloat ("spd", 100);
			Flip (2);
		}
		if (key_right) {
			rigidbody2D.velocity = new Vector2 (10, 0);
			anim.SetFloat ("spd", 100);
			Flip (0);
		}
	
		rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x/2,rigidbody2D.velocity.y/2);

	}
}
