using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiceRoll : MonoBehaviour {
	private Rigidbody rb;
	private bool isMoving = false;
	int position = 0;
	bool isKanan = true;
	private List<int> naik = new List<int>();
	private List<int> tujuanNaik = new List<int>();

	public DiceSide[] sides;
	public GameObject player1;
	public void QuitGame(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex - 2); 

	}

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
	
		naik.Add (7);
		tujuanNaik.Add (30);


		naik.Add (34);
		tujuanNaik.Add(64);

		naik.Add (58);
		tujuanNaik.Add (84);

		naik.Add (51);
		tujuanNaik.Add (86);

		naik.Add (98);
		tujuanNaik.Add (79);

		naik.Add (37);
		tujuanNaik.Add (15);



		float range = 1.1f;


	}



	public void roll()
	{
		isMoving = true;
		transform.position = new Vector3 (-5f, 10f, 1f);
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

		if(position <= 99){

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

		else{
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex - 2); 

		}

	}
}
