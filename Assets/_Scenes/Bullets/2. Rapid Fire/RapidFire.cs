using UnityEngine;
using System.Collections;

public class RapidFire : MonoBehaviour {
	
	public GameObject shotPrefab;
	public float shotDelay;

	float nextShot=0;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButton("Fire1")) TryShoot();
	}
	
	void TryShoot()
	{
		if (Time.time>nextShot)
		{
			Instantiate(shotPrefab, transform.position,transform.rotation);
			nextShot=Time.time+shotDelay;
		}
	}
}

