using UnityEngine;
using System.Collections;

public class GrowBall : MonoBehaviour {


	private Transform ballSize;
	private float startTime;
	public float period=1.0f;


	void Start () {
		//getting transform of the local object
		ballSize = gameObject.GetComponent<Transform>();
		//setting size to double
		ballSize.localScale = ballSize.localScale + new Vector3(1.0F, 1.0F,1.0F);
		//logging time when started
		startTime=Time.time+6;
		//setting player health in another script
		gameObject.GetComponent<Health>().ApplyHeal(99.0f);
		period = 1.0f;

	}

	void reduceSize(){
		ballSize.localScale = ballSize.localScale-new Vector3 (0.1F, 0.1F, 0.1F);
		gameObject.GetComponent<Health>().ApplyDamage(5.0f);


	}
	
	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Enemy") {
			reduceSize();
		}
	}
	void Update () {
		
		if (Time.time - startTime >= period) // is it time to reduce the size
		{
			reduceSize ();
			startTime = Time.time;
		}	
	}
	public void  increaseSize(){
		ballSize.localScale = ballSize.localScale + new Vector3 (0.3F, 0.3F, 0.3F);
		gameObject.GetComponent<Health>().ApplyHeal(30.0f);
	}
		
}
