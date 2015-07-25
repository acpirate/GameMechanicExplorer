using UnityEngine;
using System.Collections;

public class AnimationScript : MonoBehaviour {

	Animator myAnimator;
	Rigidbody2D myBody;

	public float idleMin;
	public float idleMax;
	
	float idleCountdown=0f;

	void Awake() 
	{
		myBody=GetComponent<Rigidbody2D>();
		myAnimator=GetComponent<Animator>();
	}

	// Use this for initialization
	void Start () {
		idleCountdown=Random.Range(idleMin,idleMax);	
	}
	
	// Update is called once per frame
	void Update () 
	{
		float tempDirection = Input.GetAxisRaw("Horizontal");

		if (Mathf.Abs(tempDirection)>float.Epsilon) PlayRunningAnimation();
		else StopRunningAnimation();
		
		idleCountdown-=Time.deltaTime;
		if (idleCountdown<=0) PlayIdleAnimation();
	}

	void PlayRunningAnimation()
	{
		myAnimator.SetBool("running",true);

		if (myBody.velocity.x>float.Epsilon) transform.localScale=new Vector3 (1,1,1);
		if (myBody.velocity.x<float.Epsilon*-1) transform.localScale=new Vector3(-1,1,0);
	}

	void StopRunningAnimation()
	{
		myAnimator.SetBool("running",false);
	}

	void PlayIdleAnimation()
	{
		myAnimator.SetTrigger("idle");
		
		idleCountdown=Random.Range(idleMin,idleMax);
		
	}
}
