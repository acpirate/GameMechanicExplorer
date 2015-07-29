using UnityEngine;
using System.Collections;

public class ShotController : MonoBehaviour {

	public float lifeTime;
	public float speed;

	Rigidbody2D myBody;

	void Awake()
	{
		myBody=GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start () {
		SetSpeed();
		//myBody.velocity=new Vector2(speed,0);
		Destroy(gameObject, lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetSpeed()
	{

		myBody.velocity=transform.up.normalized*speed;
	}
}
