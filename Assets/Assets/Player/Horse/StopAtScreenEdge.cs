using UnityEngine;
using System.Collections;

public class StopAtScreenEdge : MonoBehaviour {

	public int rightEdge;
	public int leftEdge;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		StopAtRightEdge();
		StopAtLeftEdge();
	}

	void StopAtRightEdge()
	{
		Vector2 tempLocation=transform.position;
		if (tempLocation.x>rightEdge)
			transform.position=new Vector2(rightEdge,tempLocation.y);

	}

	void StopAtLeftEdge()
	{
		Vector2 tempLocation=transform.position;
		if (tempLocation.x<leftEdge)
			transform.position=new Vector2(leftEdge,tempLocation.y);
	}
}
