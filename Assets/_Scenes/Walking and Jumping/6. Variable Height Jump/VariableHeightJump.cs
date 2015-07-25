using UnityEngine;
using System.Collections;

public class VariableHeightJump : MonoBehaviour {

	Rigidbody2D myBody;
	Animator myAnimator;
	
	public float jumpForce;
	public float jumpAcceleration;
	public float maxJumpTime;

	float currentJumpTime;

	bool jumping=false;
	bool doubleJump=false;
	bool jumpKeyReleased=false;

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
		if (jumping && !Input.GetKey(KeyCode.UpArrow)) jumpKeyReleased=true;
		if (jumping) currentJumpTime+=Time.deltaTime;
	}

	void FixedUpdate()
	{
		//if (jumping && Input.GetKey(KeyCode.UpArrow) && myBody.velocity.y > 0 && !jumpKeyReleased && (currentJumpTime<maxJumpTime))
		if (jumping && Input.GetKey(KeyCode.UpArrow) && myBody.velocity.y>0 && !jumpKeyReleased && (currentJumpTime<maxJumpTime))
		{
			MoreJump();
		}
	}

	void MoreJump() {
		myBody.AddForce(new Vector2(0,jumpAcceleration));
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
		currentJumpTime=0;
		myAnimator.SetTrigger("jump");

		jumpKeyReleased=false;
		jumping=true;
		myBody.velocity=new Vector2(myBody.velocity.x, jumpForce);
	}
	
	void Landing()
	{
		currentJumpTime=0f;
		doubleJump=false;
		myAnimator.SetTrigger("land");
		jumping=false;
	}
	
}