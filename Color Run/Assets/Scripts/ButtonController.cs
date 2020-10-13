using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void goToGame(){
       SceneManager.LoadScene("Game");
    }

    public void sair(){
        Application.Quit();
    }
}
