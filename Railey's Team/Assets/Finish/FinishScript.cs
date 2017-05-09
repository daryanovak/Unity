using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour {

	public void Replay () {
        SceneManager.LoadScene(0);
    }

    public void Home () {
        SceneManager.LoadScene(1);

    }
}
