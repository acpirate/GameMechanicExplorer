using UnityEngine;
using System.Collections;

public class Homing : MonoBehaviour {

	public float maxSpeed;
	public float thrustForce;
	public float turnRate;


	GameObject target;

	Rigidbody2D myBody;

	void Awake()
	{
		target=null;
		myBody=GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() 
	{
		Thrust();
		TurnToTarget();
	}


	void TurnToTarget()
	{
		Vector3 targetPosition=Vector3.zero;

		if (target==null)
		{
			targetPosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}
		targetPosition.z=0;

		Vector3 vectorToTarget = targetPosition - transform.position;
		float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
		Quaternion q = Quaternion.AngleAxis(angle-90, Vector3.forward);
		transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * turnRate);

	}

	void Thrust()
	{

			myBody.AddForce(transform.up*thrustForce*Time.deltaTime);

		if (myBody.velocity.sqrMagnitude>maxSpeed*maxSpeed)
			myBody.velocity=myBody.velocity.normalized*maxSpeed;
	}
}
