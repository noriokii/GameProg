using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoll : MonoBehaviour {
	private Rigidbody rb;
	private bool isMoving = false;
	int position = 0;
	bool isKanan = true;
	private List<int> naik = new List<int>();
	private List<int> tujuanNaik = new List<int>();

	public DiceSide[] sides;
	public GameObject player1;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		naik.Add (7);
		naik.Add (33);
		tujuanNaik.Add (43);
		tujuanNaik.Add (30);

		float range = 1.1f;

	}


	public void roll()
	{
		isMoving = true;
		transform.position = new Vector3 (-8f, 10f, 1f);
		rb.velocity = new Vector3 (0f, 0.1f, 0f);
		rb.AddTorque (new Vector3(Random.Range(30f, 50f), Random.Range(30f, 50f), Random.Range(30f, 50f)));

		for (int i = 0; i < sides.Length; i++) {
			sides [i].isSideDown = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			roll ();
		}

		if (rb.velocity == Vector3.zero && rb.angularVelocity == Vector3.zero && isMoving) {
			isMoving = false;
			for (int i = 0; i < sides.Length; i++) {
				if (sides [i].isSideDown) {
					Debug.Log ("dice: " + sides[i].value);
					MovePlayer (sides [i].value - 1);
					break;
				}
			}
		}
 	}
	void MovePlayer(int langkah){
		float range = 1.1f;


		for (int i = 0; i <= langkah; i++) {
			if (position == 9 || position == 19 || position == 29 || position == 39|| position == 49|| position == 59|| position == 69|| position == 79|| position == 89|| position == 99)
			{
				player1.transform.position += new Vector3(0, 0, range); //up
				isKanan = !isKanan;
			}
			else if (isKanan)
			{
				player1.transform.position += new Vector3(range, 0, 0); //right
			}

			else if (!isKanan)
				player1.transform.position += new Vector3(-range, 0, 0); //left

			position += 1;
		}

		Debug.Log(position);

		int indextujuan = 0;
		foreach (int i in naik) {
			if (position == i-1) {
				int tujuan = -1;
				int indx = 0;
				foreach (int t in tujuanNaik) {
					if (indextujuan == indx) {
						tujuan = t-1;
						break;
					}
					indx++;
				}

				MovePlayer (tujuan - position);
				break;
			}
			indextujuan++;
		}

	}
}

