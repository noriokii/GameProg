using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSCript : MonoBehaviour {

	public void PlayGameLudoh(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1); 

	}
	public void PlayGameUlarTangga(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 2); 

	}public void PlayGameOthello(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 3); 

	}



	public void QuitGame(){
		Application.Quit ();

	}
}
