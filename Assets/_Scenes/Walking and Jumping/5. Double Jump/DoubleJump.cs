using UnityEngine;
using System.Collections;

public class DoubleJump: MonoBehaviour {
	
	Rigidbody2D myBody;
	Animator myAnimator;
	
	public float jumpForce;
	
	bool jumping=false;
	bool doubleJump=false;
	
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
			if (Input.GetKeyDown(KeyCode.UpArrow)) Jump();
		}
		else
		{
			if (!(doubleJump))
			{
				if (Input.GetKeyDown(KeyCode.UpArrow)) 
				{
					doubleJump=true;
					Jump();
				}
			}
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
		doubleJump=false;
		myAnimator.SetTrigger("land");
		jumping=false;
	}
	
}