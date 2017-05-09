using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverTimer : MonoBehaviour {

	public static GameOverTimer instance;

    public Text GameOverTime;
    public Text CoinCount;

    // Use this for initialization
    void Start () {
        instance = this;
		GameOverTime.text = PlayerPrefs.GetString("GameOverTime");
        CoinCount.text = PlayerPrefs.GetString("CoinCount");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
