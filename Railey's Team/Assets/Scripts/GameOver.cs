﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public void HomePage()
    {
        SceneManager.LoadScene(0);
    }

    public void Reload()
    {
        SceneManager.LoadScene(1);
    }


}
