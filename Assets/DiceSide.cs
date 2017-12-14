using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSide : MonoBehaviour {
	public bool isSideDown = false;
	public int value = 0;

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Terrain") {
			isSideDown = true;
		}
	}

	void OnTriggerExit(Collider col) {
		if (col.gameObject.tag == "Terrain") {
			isSideDown = false;
		}
	}
}
