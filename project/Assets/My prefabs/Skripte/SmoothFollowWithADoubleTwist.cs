using UnityEngine;
using System.Collections;
namespace UnityStandardAssets.Utility
{
	public class SmoothFollowWithADoubleTwist : MonoBehaviour
	{	
		//vrijeme čekanja na inicijalnu animaciju
		public float delayTime = 6.0f;
		//time to which we will exactly wait
		private float targetTime;

		// meta koju pratimo
		[SerializeField]
		private Transform target;
		// Udaljenost do mete u x-z ravni
		[SerializeField]
		private float distance = 10.0f;
		// visina kamere u odnosu na predmet praćenja
		[SerializeField]
		private float height = 5.0f;

		[SerializeField]
		private float rotationDamping;
		[SerializeField]
		private float heightDamping;

		// pamćenje pozicije kamere i objekta za zaustavljanje kamere nakon uništenja objekta
		private Vector3 targetLastPosition;
		private Vector3 cameraLastPosition;

		void Start() { 
			targetTime = Time.time + delayTime;

		} 

		// Ova funkcija se poziva jednom po okviru
		void LateUpdate()
		{//pozicioniraj se ako je inicijalna animacija prošla
			if (targetTime < Time.time) {
				// ako je lopta mrtva - ostani na starim pozicijama
				if (!target) {
					transform.position=cameraLastPosition;
					transform.LookAt (targetLastPosition);
					return;
				} else {
					// izračun trenutne rotacije 
					var wantedRotationAngle = target.eulerAngles.y;
					var wantedHeight = target.position.y + height;

					var currentRotationAngle = transform.eulerAngles.y;
					var currentHeight = transform.position.y;

					// rotacija oko y osi
					currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

					// promjena visine
					currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);

					// preračunavanje kuta u rotaciju
					var currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);

					// postaciti poziciju u x-z ravnini na udaljenost od mete
				
					transform.position = target.position;
					transform.position -= currentRotation * Vector3.forward * distance;

					// postavljanje visine kamere
					transform.position = new Vector3 (transform.position.x, currentHeight, transform.position.z);

					// pozicioniranje kamere ka meti
					transform.LookAt (target);

					//pohrana nove pozicije
					cameraLastPosition = transform.position;
					targetLastPosition = target.position;


				}
			}
		}
	}
}