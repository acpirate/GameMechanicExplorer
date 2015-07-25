using UnityEngine;
using System.Collections;

public class BasicWalking : MonoBehaviour {

	public float speed;


	Rigidbody2D myBody;

	void Awake() {
		myBody=GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float tempDirection = Input.GetAxisRaw("Horizontal");
		if (Mathf.Abs(tempDirection)>float.Epsilon) Moving(tempDirection);
			else NotMoving();

	}




	void Moving(float direction) {

		Vector2 tempSpeed = new Vector2(speed*direction,0);
		myBody.velocity=tempSpeed;

	}

	void NotMoving() {
		myBody.velocity=new Vector2(0,0);
	}
}
