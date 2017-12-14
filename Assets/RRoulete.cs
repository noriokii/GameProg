using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RRoulete : MonoBehaviour {
	public Rigidbody rb;
	// Use this for initialization
	void Start () {
		Rotate ();
	}
	
	// Update is called once per frame
	void Update () {
		if (rb.angularVelocity.z <= 0.1f) {
			rb.angularVelocity = Vector3.zero;
			Debug.Log (transform.rotation.eulerAngles.x);
			//if(transform.rotation.eulerAngles.x <= 120 && transform.rotation.eulerAngles.x>=0){
				

			//}
		}
	}
	void Rotate (){
		rb.angularVelocity = new Vector3 (0f,0f,Random.Range(500f,1000f));

	}
}
