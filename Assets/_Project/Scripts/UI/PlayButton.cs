﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadSceneAsync("Game");
    }
}