using UnityEngine;
using System.Collections;

public class DrawTrajectory : MonoBehaviour {

	public int numberOfSegments;
	public GameObject segmentPrefab;
	public float pathEndTime;



	float projectileBaseSpeed;

	GameObject[] segments;
	//Vector3 projectileAngle;

	// Use this for initialization
	void Start () {
		segments=new GameObject[numberOfSegments];
		projectileBaseSpeed=1000;
		for (int counter=0; counter<numberOfSegments; counter++)
		{
			segments[counter]=Instantiate(segmentPrefab);
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int counter=0;counter<numberOfSegments; counter++)
		{
			float segmentTime=pathEndTime/numberOfSegments*counter;

			Vector3 projectileVelocity=transform.up.normalized*projectileBaseSpeed;

			Vector3 segmentLocation=PlotTrajectoryAtTime(transform.position, projectileVelocity, segmentTime);

			segments[counter].transform.position=segmentLocation;

		}

	}

	public Vector3 PlotTrajectoryAtTime (Vector3 start, Vector3 startVelocity, float time) {
		return start + startVelocity*time + Physics.gravity*time*time*0.5f;
	}
}
