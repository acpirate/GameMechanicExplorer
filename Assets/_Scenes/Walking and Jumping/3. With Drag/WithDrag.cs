using UnityEngine;
using System.Collections;

public class WithDrag : MonoBehaviour {
	
	public float topSpeed;
	public float accelerationRate;
	public float dragRate;
	
	
	Rigidbody2D myBody;
	
	void Awake() {
		myBody=GetComponent<Rigidbody2D>();
	}
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float tempDirection = Input.GetAxisRaw("Horizontal");
		if (Mathf.Abs(tempDirection)>float.Epsilon) Moving(tempDirection);
		else
			Decelerate();
		
	}
	
	
	
	
	void Moving(float direction) {
		
		if (myBody.velocity.x>0 && direction<0) Decelerate();
		if (myBody.velocity.x<0 && direction>0) Decelerate();
		
		Vector2 tempSpeed=new Vector2(accelerationRate*direction*Time.deltaTime,0);
		Vector2 currentSpeed=myBody.velocity;
		
		Vector2 totalSpeed=new Vector2(currentSpeed.x+tempSpeed.x, myBody.velocity.y);
		
		
		myBody.velocity=totalSpeed;
		
		
	}
	
	void Decelerate() {
		
		myBody.velocity=new Vector2(myBody.velocity.x*dragRate,myBody.velocity.y);
		//myBody.velocity=myBody.velocity*.9f;
		
		
	}
}
