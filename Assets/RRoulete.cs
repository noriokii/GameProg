using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RRoulete : MonoBehaviour {
	public Rigidbody rb;
	int position=0;
	int langkah;
	bool isKanan = true;
	bool isMove = false;
	public Vector3[] positions;
	public GameObject LudohPlayer;
	// Use this for initialization
	void Start () {
		Rotate ();

	}
	
	// Update is called once per frame
	void Update () {
		if (rb.angularVelocity.z <= 0.1f&&isMove) {
			rb.angularVelocity = Vector3.zero;
			Debug.Log (transform.rotation.eulerAngles.x);
			if(transform.rotation.eulerAngles.x <= 120 && transform.rotation.eulerAngles.x>=0){
				langkah = 1;
			}
			else if(transform.rotation.eulerAngles.x <= 240 && transform.rotation.eulerAngles.x>=120){
				langkah = 2;

			}
			else if(transform.rotation.eulerAngles.x <= 360 && transform.rotation.eulerAngles.x>=240){
				langkah = 3;
			
			}
			MovePlayer (langkah);


		}
	}
	void Rotate (){
		rb.angularVelocity = new Vector3 (0f,0f,Random.Range(500f,1000f));
		isMove = true;

	}
	void MovePlayer(int langkah){
		float range = 1.1f;
		isMove = false;

		for (int i = 0; i <= langkah; i++) {
			//if (position == 2)
			//{
			//	LudohPlayer.transform.position += new Vector3(0, 0, range); //up
			//	LudohPlayer.transform.position += new Vector3
			//	isKanan = !isKanan;
			//}
			if (isKanan) {
				LudohPlayer.transform.position += new Vector3 (range, 0, 0); //right
			} else if (!isKanan)
				LudohPlayer.transform.position += new Vector3 (-range, 0, 0); //left

			position += 1;
		}
	}
}
