using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void GoToGame(){
       SceneManager.LoadScene("Game");
    }

    public void Sair(){
        Application.Quit();
    }

    public void GoToMenu(){
        SceneManager.LoadScene("Menu");
    }

    public void HowToPlay(){
        SceneManager.LoadScene("HowToPlay");
    }
}
