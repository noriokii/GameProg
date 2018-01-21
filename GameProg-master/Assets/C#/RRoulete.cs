using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RRoulete : MonoBehaviour {
	public Rigidbody rb;
	int position=0;
	int langkah;
    int turn=1;
	bool isKanan = true;
	bool isMove = false;
	public Vector3[] positions;
	public sekarang LudohPlayerMerah;
    public sekarang LudohPlayerHijau;
    public sekarang LudohPlayerKuning;
    public sekarang LudohPlayerBiru;
	public Text time;
	public bool finish = false;


	public void QuitGame(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex -1); 

	}


    // Use this for initialization
    void Start () {
		Rotate ();
		do{
		int number = 0;
		number++;
			time.text = number.ToString();}

		while(finish == true);



	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Rotate();
        }
        if (rb.angularVelocity.z <= 0.1f && isMove)
        {
            rb.angularVelocity = Vector3.zero;
            Debug.Log(transform.rotation.eulerAngles.x);
            if (transform.rotation.eulerAngles.x <= 120 && transform.rotation.eulerAngles.x >= 0)
            {
                langkah = 1;
            }
            else if (transform.rotation.eulerAngles.x <= 240 && transform.rotation.eulerAngles.x >= 120)
            {
                langkah = 2;

            }
            else if (transform.rotation.eulerAngles.x <= 360 && transform.rotation.eulerAngles.x >= 240)
            {
                langkah = 3;

            }
            MovePlayer(langkah);
                
                
            
        }
	}
	void Rotate (){
		rb.angularVelocity = new Vector3 (0f,0f,Random.Range(500f,1000f));
		isMove = true;
        Debug.Log(rb.angularVelocity);
		Debug.Log (time);

    }
	void MovePlayer(int langkah){
		float range = 1.1f;
		isMove = false;
		LudohPlayerBiru.index = 8;
		LudohPlayerHijau.index = 22;
		LudohPlayerKuning.index = 15;

	



        for (int i = 0; i <= langkah; i++) {
            //if (position == 2)
            //{
            //	LudohPlayer.transform.position += new Vector3(0, 0, range); //up
            //	LudohPlayer.transform.position += new Vector3
            //	isKanan = !isKanan;
            //}
            if (turn == 1)
            {
				if (langkah + LudohPlayerMerah.index >= 28) {
					langkah = LudohPlayerMerah.index - langkah;
					LudohPlayerMerah.index = 0;
				}
				LudohPlayerMerah.transform.localPosition = positions [LudohPlayerMerah.index + 1];
				LudohPlayerMerah.index++;

            }
            else if (turn == 2) {
				if (langkah + LudohPlayerBiru.index >= 28) {
					langkah = LudohPlayerBiru.index - langkah;
					LudohPlayerBiru.index = 0;

				}
				LudohPlayerBiru.transform.localPosition = positions [LudohPlayerBiru.index + 1];
				LudohPlayerBiru.index++;
            }
            else if (turn == 3) {
				if (langkah + LudohPlayerKuning.index >= 28) {
					langkah = LudohPlayerKuning.index - langkah;
					LudohPlayerKuning.index = 0;

				}
				LudohPlayerKuning.transform.localPosition = positions [LudohPlayerKuning.index + 1];
				LudohPlayerKuning.index++;
            }
            else if (turn == 4)
            {
				if (langkah + LudohPlayerHijau.index >= 28) {
					langkah = LudohPlayerHijau.index - langkah;
					LudohPlayerHijau.index = 0;

				}
				LudohPlayerHijau.transform.localPosition = positions [LudohPlayerHijau.index + 1];
				LudohPlayerHijau.index++;
            }
        }
        if (turn == 1) {
            turn = 2;
        }
        else if (turn == 2){
            turn = 3;
        }
        else if (turn == 3)
        {
            turn = 4;
        }
        else if (turn == 4)
        {
            turn = 1;
        }
    }
}
