using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.instance.StartGame = true;
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ToDesk()
    {
        Application.Quit();
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }
}
