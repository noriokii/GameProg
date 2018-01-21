using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class telo : MonoBehaviour {
    public Renderer[] cubes;
    int index;
    int turn;
    public int[,] posisi = new int[8, 8] {
        {0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0},
        {0,0,0,1,2,0,0,0},
        {0,0,0,2,1,0,0,0},
        {0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0}
    };
    public static Vector3 mousePos;
    public Material merah, biru;

	public void QuitGame(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex - 2); 

	}
    

	// Use this for initialization
	void Start () {
        cubes[35].material = merah;
        cubes[28].material = merah;
        cubes[36].material = biru;
        cubes[27].material = biru;
    }
	
	// Update is called once per frame
	void Update () { }
    public void input(int col, int row) {
        index = col + row*8;
        cubes[index].material = (turn == 1) ? merah : biru;
	
		posisi[col,row] = 1;



        if (turn == 1) {
			

            turn = 2;
        }
        else{
			
            turn = 1;
        }


    }
  


		
	
}
