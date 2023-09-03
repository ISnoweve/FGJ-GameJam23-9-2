using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public void StartGame(){
GameManager.instance.StartGame = true;
    }

    public void ToMenu()
    {
        // SceneManager.LoadScene("Menu");
    }
    public void ToDesk()
    {
        Application.Quit();
    }
}
