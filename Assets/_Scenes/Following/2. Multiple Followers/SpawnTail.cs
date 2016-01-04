using UnityEngine;
using System.Collections;

public class SpawnTail : MonoBehaviour {

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
			followerPiece.GetComponent<FollowTarget>().followTarget=leaderPiece;
			followerPiece.GetComponent<FollowTarget>().moveSpeed=followSpeed;
			followerPiece.GetComponent<FollowTarget>().followDistance=followDistance;
			followerPiece.GetComponent<LookAtTarget>().lookTarget=leaderPiece;
			leaderPiece=followerPiece;
		}
	}
}
