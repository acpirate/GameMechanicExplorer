using UnityEngine;
using System.Collections;

public class Aiming : MonoBehaviour {

	//Quaternion baseRotation;

	void Awake()
	{
//		baseRotation=transform.rotation;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RotateToMouse();
	}

	void RotateToMouse() {

		Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 dir = Input.mousePosition - pos;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle+270, Vector3.forward); 



	}
}
