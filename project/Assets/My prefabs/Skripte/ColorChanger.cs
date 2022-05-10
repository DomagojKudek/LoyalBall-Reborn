using UnityEngine;
using System.Collections;




public class ColorChanger : MonoBehaviour {



	// setup the game
	void Start () {

		gameObject.GetComponent<Renderer>().material.color = Color.blue;
	
	}



	public void changeColor(){
		
		gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV();


	}

	

}
