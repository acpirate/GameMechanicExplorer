using UnityEngine;
using System.Collections;

public class shellcontroller : MonoBehaviour {

	public float lifeTime;
	public float speed;
	
	Rigidbody myBody;
	
	void Awake()
	{
		myBody=GetComponent<Rigidbody>();
	}
	
	// Use this for initialization
	void Start () {
		SetSpeed();
		//myBody.velocity=new Vector2(speed,0);
		Destroy(gameObject, lifeTime);

	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y<-300) Destroy(gameObject);

		transform.up=myBody.velocity.normalized;
	}
	
	public void SetSpeed()
	{
		
		myBody.velocity=transform.up.normalized*speed;
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.CompareTag("ground")) Destroy(gameObject);
	}
}
