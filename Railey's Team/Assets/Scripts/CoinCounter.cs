using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour {

    public static CoinCounter instance;

    public Text CoinCounterBar;

    public int CoinCount;

    // Use this for initialization
    void Start () {
        instance = this;
        CoinCount = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RefreshCounter(int CoinsCount)
    {   
        CoinCounterBar.text = CoinsCount.ToString();
    }
}
