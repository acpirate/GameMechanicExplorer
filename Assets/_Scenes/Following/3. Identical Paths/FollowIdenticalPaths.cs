using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FollowIdenticalPaths : MonoBehaviour {
	
	public float moveSpeed;
	public float followDistance;
	
	public GameObject followTarget;

	public List<Vector3> history;
	public int historyLength;
	public float historyInterval;

	float nextHistory=0;

	Vector3 targetPosition;

	public FollowIdenticalPaths targetController;

	void Awake()
	{
		history=new List<Vector3>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		SetTargetPosition();
		DoFollow();
		SetHistory();
	}

	void SetHistory()
	{
		if (Time.time>nextHistory)
		{
			nextHistory=Time.time+historyInterval;
			history.Insert(0,transform.position);
			if (history.Count>historyLength)
			{
				history.RemoveAt(historyLength);
			}
		}
	}
	
	
	void SetTargetPosition()
	{
		if (followTarget==null)
		{
			targetPosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}
		else
		{
			if (targetController.history.Count>0)
			{
				targetPosition=targetController.history[targetController.history.Count-1];
			}
			else
			targetPosition=followTarget.transform.TransformPoint(0,-followDistance,0);
		}
	}
	
	void DoFollow()
	{
		if (Vector3.Distance(transform.position,targetPosition)<followDistance)
		{
			return;
		}

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
