using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputan : MonoBehaviour {
    public int col, row;
    public telo bebas;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnMouseDown()
    {

        bebas.input(col,row);
    }
}
