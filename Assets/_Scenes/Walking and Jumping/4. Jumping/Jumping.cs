using UnityEngine;
using System.Collections;

public class Jumping : MonoBehaviour {

	Rigidbody2D myBody;
	Animator myAnimator;

	public float jumpForce;

	bool jumping=false;

	void Awake() 
	{
		myBody=GetComponent<Rigidbody2D>();
		myAnimator=GetComponent<Animator>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!(jumping))
		{
			if (Input.GetKey(KeyCode.UpArrow)) Jump();
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (jumping)
		{
			if (coll.gameObject.tag == "ground")
				Landing();
		}
	}

	void Jump()
	{	
		myAnimator.SetTrigger("jump");

		jumping=true;
		myBody.AddForce(new Vector2(0,jumpForce),ForceMode2D.Impulse);
	}

	void Landing()
	{
		myAnimator.SetTrigger("land");
		jumping=false;
	}

}
