using UnityEngine;
using System.Collections;

public class ParticleDamage : MonoBehaviour {
	
	public float damageAmount = 10.0f;
	


	public GameObject explosionPrefab;

	private float savedTime = 0;

	void OnParticleCollision (GameObject collidedObject) 				
	{	
	//Čestice rade štetu samo na igraču
		if (collidedObject.tag == "Player") {
			//ako postoji skripta za život na objektu načini mu štetu
			if (collidedObject.GetComponent<Health> () != null) {	
				collidedObject.GetComponent<Health> ().ApplyDamage (damageAmount);
			
			}
		}
	}
}