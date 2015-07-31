using UnityEngine;
using System.Collections;

public class SpaceShipMoveController : MonoBehaviour {

	public float rotationAngle;
	public float thrustForce;
	public float maxSpeed;

	ParticleSystem thrustVisual;
	Rigidbody2D myBody;
	bool thrusting=false;

	void Awake()
	{
		myBody=GetComponent<Rigidbody2D>();
		thrustVisual=GetComponentInChildren<ParticleSystem>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetAxisRaw("Vertical")>0) Thrust();
			else NoThrust();

		float turnDirection=Input.GetAxis("Horizontal");
		if (Mathf.Abs(turnDirection)>float.Epsilon) Turn (turnDirection);

	}

	void FixedUpdate()
	{
		if (thrusting) AddThurstForce();
	}

	void AddThurstForce()
	{

		if (myBody.velocity.sqrMagnitude<maxSpeed*maxSpeed) myBody.AddForce(transform.up*thrustForce*Time.deltaTime);
			//myBody.velocity=myBody.velocity.normalized*maxSpeed;
	}

	void Thrust()
	{
		thrusting=true;
		thrustVisual.Play();
	}

	void NoThrust()
	{
		thrusting=false;
		thrustVisual.Stop();
	}

	void Turn(float direction)
	{
		Vector3 currentRotationEuler=transform.rotation.eulerAngles;
		Quaternion newRotation= Quaternion.Euler(currentRotationEuler.x,currentRotationEuler.y,
		                                         currentRotationEuler.z-direction*rotationAngle*Time.deltaTime);

		transform.rotation=newRotation;
	}
}
