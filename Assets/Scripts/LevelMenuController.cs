using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        Application.LoadLevel("GamePlayLv1");
    }

    public void PlayLv2()
    {
        Application.LoadLevel("GamePlayLv2");
    }

    public void PlayLv3()
    {
        Application.LoadLevel("GamePlayLv3");
    }

    public void PlayLv4()
    {
        Application.LoadLevel("GamePlayLv4");
    }
    public void BackToMenu()
    {
        Application.LoadLevel("MainMenu");
    }
}
