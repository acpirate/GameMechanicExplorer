using UnityEngine;
using System.Collections;

public class LunarLanderGameController : MonoBehaviour {

	public GameObject playerPrefab;

	public static bool playerDead=false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (playerDead)
		{
			Respawn();
		}
	}

	void Respawn()
	{
		playerDead=false;

		Vector3 playerLocation=new Vector3(Random.Range(-620f,620f),318f,0);
		Quaternion playerRotation=Quaternion.Euler(new Vector3(0,0,Random.Range(0,360)));

		Instantiate(playerPrefab,playerLocation,playerRotation);
	}

}
