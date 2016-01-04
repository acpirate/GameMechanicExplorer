using UnityEngine;
using System.Collections;

public class FollowMouse : MonoBehaviour {

	public float moveSpeed;
	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		DoFollow();
	}

	void DoFollow()
	{
		Vector3 target=Camera.main.ScreenToWorldPoint(Input.mousePosition);
		//force the sprite to stay on the same plane
		target.z=0;

		transform.position=Vector3.MoveTowards(transform.position, target, moveSpeed *Time.deltaTime);
	}
}
