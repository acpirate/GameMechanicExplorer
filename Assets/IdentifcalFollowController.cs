using UnityEngine;
using System.Collections;

public class IdentifcalFollowController : MonoBehaviour {
	
	public float moveSpeed;
	public float followDistance;
	
	public GameObject followTarget;
	
	Vector3 targetPosition;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		SetTargetPosition();
		DoFollow();
	}
	
	
	void SetTargetPosition()
	{
		if (followTarget==null)
		{
			Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);


			Vector3 targetVector = Vector3.Normalize(transform.position - mousePosition);


			targetPosition = targetVector*followDistance + mousePosition;
			//targetPosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}
		else
		{
			targetPosition=followTarget.transform.TransformPoint(0,-followDistance,0);
		}
	}
	
	void DoFollow()
	{
		
		
		//force the sprite to stay on the same plane
		Vector3 targetWithZeroZ=new Vector3 (targetPosition.x, targetPosition.y, 0);
		
		Vector3 finalDestination=Vector3.zero;
		
		if (followTarget==null)
		{

			finalDestination=Vector3.MoveTowards(transform.position, targetWithZeroZ, moveSpeed *Time.deltaTime);



		}
		else
		{
			finalDestination=Vector3.Lerp(transform.position, targetWithZeroZ, moveSpeed * Time.deltaTime);
		}
		
		transform.position=finalDestination;
		
	}
	

}
