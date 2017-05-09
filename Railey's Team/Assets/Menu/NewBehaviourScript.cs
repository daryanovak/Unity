using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour {
    //public AudioClip myclip;
    
	public void Starter ()
    {
        //AudioSource.PlayClipAtPoint(myclip, transform.position);
        SceneManager.LoadScene(1);	
	}

    public void Exit()
    {
        Application.Quit();
    }
	
	
} 
