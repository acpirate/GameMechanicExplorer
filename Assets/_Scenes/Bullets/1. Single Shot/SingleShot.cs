using UnityEngine;
using System.Collections;

public class SingleShot : MonoBehaviour {


	public GameObject shotPrefab;
	public GameObject shotContainer;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown("Fire1")) TryShoot();
	}

	void TryShoot()
	{
		if (shotContainer.transform.childCount<1)
		{
			GameObject tempShot=Instantiate(shotPrefab, transform.position,transform.rotation) as GameObject;
			tempShot.transform.SetParent(shotContainer.transform);
		}
	}
}
