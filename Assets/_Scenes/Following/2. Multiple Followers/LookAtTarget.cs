using UnityEngine;
using System.Collections;

public class LookAtTarget : MonoBehaviour {

	public GameObject lookTarget;

	Vector3 targetPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		SetTargetPosition();
		LookAtPosition();
	
	}

	void SetTargetPosition()
	{
		if (lookTarget==null)
		{
			targetPosition=Input.mousePosition;
		}
		else
		{
			targetPosition=Camera.main.WorldToScreenPoint(lookTarget.transform.position);
		}
	}

	void LookAtPosition()
	{
		Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 dir = targetPosition - pos;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle+270, Vector3.forward); 
	}
}
