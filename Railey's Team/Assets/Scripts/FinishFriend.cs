using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishFriend : MonoBehaviour
{
    private GameObject myobj;
    static string str;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       myobj = GameObject.Find("Character");
        str = myobj.GetComponent<Timer>().minutes + "min " + myobj.GetComponent<Timer>().seconds + "sec";
       // Debug.Log(str);
        PlayerPrefs.SetString("GameOverTime", str);
        PlayerPrefs.SetString("CoinCount", CoinCounter.instance.CoinCounterBar.text);
        SceneManager.LoadScene(2);

    }
}
  
    