using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jalan : MonoBehaviour {

//	Vector3 satu = new Vector3(0, 0, 0);
	public GameObject dadu;
	//public GameObject dadu3;
	//public GameObject daduBoongan;
	//public GameObject daduBoongan1;
	//public GameObject daduBoongan2;
	private List<int> naik = new List<int>();
	private List<int> tujuanNaik = new List<int>();
	Vector3[] arah = new Vector3[6];
	int position = 0;
	bool isKanan = true;
	//int mengarahKeDadu = 0;
	//bool isRotating = false;

	// Use this for initialization
	void Start () {
		naik.Add (7);
		tujuanNaik.Add (30);
		//naik.Add (11);
		foreach (int i in naik) {
			Debug.Log (i);
		}
		//anim
		arah[0] = new Vector3(0, 0, 0);
        arah[1] = new Vector3(0, 180, 0);
        arah[2] = new Vector3(0, -90, 0);
        arah[3] = new Vector3(0, 90, 0);
        arah[4] = new Vector3(-90, 0, 0);
        arah[5] = new Vector3(90, 0, 0);

    }
	
	// Update is called once per frame
	void Update () {
		//if (isRotating) {
		//dadu.transform.rotation = Quaternion.Slerp (dadu.transform.rotation, daduBoongan.transform.rotation, 0.5f);
			//dadu.transform.rotation = Quaternion.Slerp (dadu.transform.rotation, daduBoongan1.transform.rotation, 0.5f);
			//dadu.transform.rotation = Quaternion.Slerp (dadu.transform.rotation, daduBoongan2.transform.rotation, 0.5f);
			//if (dadu.transform.rotation == daduBoongan.transform.rotation || dadu.transform.rotation == daduBoongan1.transform.rotation || dadu.transform.rotation == daduBoongan2.transform.rotation ) {
			//	isRotating = false;
		//	}
		//}
		//else if (mengarahKeDadu == 3 && isRotating == false) {
			
		//	dadu.transform.rotation = Quaternion.Slerp (dadu.transform.rotation, dadu3.transform.rotation, 0.2f);
			//if (dadu.transform.rotation == dadu3.transform.rotation) {
			//	Debug.Log ("STOP");
			//	mengarahKeDadu = 0;
			//}
				
		//}
		if (Input.GetKeyDown (KeyCode.Space)) {
			
			int langkah ;
            
            
			langkah = 0;// Random.Range (0, 5);
			//isRotating = true;
			//mengarahKeDadu = 3;
			dadu.gameObject.transform.localRotation = Quaternion.Euler(arah[langkah]);
			MovePlayer(langkah);
			//Debug.Log (langkah);
		}
			
	}

	void MovePlayer(int langkah){
		float range = 1.1f;
		if (position < 99) {
			for (int i = 0; i <= langkah; i++) {
				if (position == 9 || position == 19 || position == 29 || position == 39 || position == 49 || position == 59 || position == 69 || position == 79 || position == 89) {
					transform.position += transform.up * range;
					isKanan = !isKanan;
				}
			//else if(position == 7){
		//		transform.position += transform.up * tujuh;
		//		transform.position += transform.right * tujuh;
		//		isKanan = !isKanan;
		//	}
            else if (isKanan) {
					transform.position += transform.right * range;
				} else if (!isKanan)
					transform.position -= transform.right * range;
			
				position += 1;
			}




			int indextujuan = 0;
			foreach (int i in naik) {
				if (position == i - 1) {
					int tujuan = -1;
					int indx = 0;
					foreach (int t in tujuanNaik) {
						if (indextujuan == indx) {
							tujuan = t - 1;
							Debug.Log (tujuan);
							break;
						}
						indx++;
					}

					MovePlayer (tujuan - position);
					break;
				}
				indextujuan++;
			}
		} else {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex - 2); 

		}

	}
}
