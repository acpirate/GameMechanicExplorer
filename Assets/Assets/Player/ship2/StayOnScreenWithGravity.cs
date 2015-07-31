using UnityEngine;
using System.Collections;

public class StayOnScreenWithGravity : MonoBehaviour {

	Rigidbody2D myBody;

	void Awake()
	{
		myBody=GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x>640)
		{
			transform.position=new Vector3 (640,transform.position.y, transform.position.z);
			myBody.velocity=new Vector2(0,myBody.velocity.y);

		}
		if (transform.position.x<-640)
		{
			transform.position=new Vector3 (-640,transform.position.y, transform.position.z);
			myBody.velocity=new Vector2(0,myBody.velocity.y);
		}
		if (transform.position.y>360)
		{
			transform.position=new Vector3 (transform.position.x,360, transform.position.z);
			myBody.velocity=new Vector2(myBody.velocity.x, 0);
		}
		if (transform.position.y<-360)
			transform.position=new Vector3 (transform.position.x,-360, transform.position.z);
		
	}
	
}
