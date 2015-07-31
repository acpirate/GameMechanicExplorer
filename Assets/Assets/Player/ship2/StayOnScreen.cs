using UnityEngine;
using System.Collections;

public class StayOnScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x>640)
			transform.position=new Vector3 (-640,transform.position.y, transform.position.z);
		if (transform.position.x<-640)
			transform.position=new Vector3 (640,transform.position.y, transform.position.z);
		if (transform.position.y>360)
			transform.position=new Vector3 (transform.position.x,-360, transform.position.z);
		if (transform.position.y<-360)
			transform.position=new Vector3 (transform.position.x,360, transform.position.z);

	}
}
