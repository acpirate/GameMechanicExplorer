using UnityEngine;
using System.Collections;

public class SpawnIdenticalFollowTail : MonoBehaviour {

	public GameObject tailPrefab;
	
	public float followDistance;
	public float followSpeed;
	public int tailCount;
	
	void Awake()
	{
		DoSpawnTail();
	}
	
	void DoSpawnTail()
	{
		GameObject leaderPiece = gameObject;
		for (int tailCounter=0;tailCounter<tailCount;tailCounter++)
		{
			GameObject followerPiece=(GameObject) Instantiate(tailPrefab,transform.position,transform.rotation);
			followerPiece.GetComponent<FollowIdenticalPaths>().followTarget=leaderPiece;
			followerPiece.GetComponent<FollowIdenticalPaths>().moveSpeed=followSpeed;
			followerPiece.GetComponent<FollowIdenticalPaths>().followDistance=followDistance;
			followerPiece.GetComponent<FollowIdenticalPaths>().targetController=leaderPiece.GetComponent<FollowIdenticalPaths>();
			followerPiece.GetComponent<LookAtTarget>().lookTarget=leaderPiece;
			leaderPiece=followerPiece;
		}
	}
}
