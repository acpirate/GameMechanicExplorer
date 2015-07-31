using UnityEngine;
using System.Collections;

public class LunarLanderController : MonoBehaviour {

	public GameObject explosionPrefab;

	void Awake()
	{
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.CompareTag("ground"))
		{
			if (col.relativeVelocity.magnitude>100f)
			{
				Explode();
			}

			if (transform.rotation.eulerAngles.z>15f && transform.rotation.eulerAngles.z<345f)
			{
				Explode ();
			}
			transform.rotation=Quaternion.Euler(new Vector3(0,0,0));
		}
	}

	void Explode()
	{
		LunarLanderGameController.playerDead=true;
		Instantiate(explosionPrefab,transform.position, transform.rotation);
		Destroy(gameObject);
	}

}
