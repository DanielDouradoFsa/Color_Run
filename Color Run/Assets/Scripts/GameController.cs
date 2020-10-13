using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject gameOver;
    public Text scoreText;
    public GameObject azulText;
    public GameObject amareloText;
    public GameObject vermelhoText;
    public float score;
    private PlayerController player;
    private BoxCollider bcAzul;
    private BoxCollider bcAmarelo;
    private BoxCollider bcVermelho;
    public float waitTime=3f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        bcVermelho = GameObject.FindGameObjectWithTag("Vermelho").GetComponent<BoxCollider>();
        bcAzul = GameObject.FindGameObjectWithTag("Azul").GetComponent<BoxCollider>();
        bcAmarelo = GameObject.FindGameObjectWithTag("Amarelo").GetComponent<BoxCollider>();

        if(!player.isDead){
        score += Time.deltaTime * player.speed;
        scoreText.text = Mathf.Round(score).ToString() + "m";
        }

        if(player.isDead){
            azulText.SetActive(false);
            amareloText.SetActive(false);
            vermelhoText.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene("Game");
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene("Menu");
        }
    }

    public void ShowGameOver(){
        gameOver.SetActive(true);
    }

    public void azul(){
        azulText.SetActive(true);
        amareloText.SetActive(false);
        vermelhoText.SetActive(false);
        Invoke("azulEscolhido",waitTime);
    }
    public void amarelo(){
        amareloText.SetActive(true);
        vermelhoText.SetActive(false);
        azulText.SetActive(false);
        Debug.Log("amarelo2");
        Invoke("amareloEscolhido",waitTime);
       
    }
    public void vermelho(){
        vermelhoText.SetActive(true);
        amareloText.SetActive(false);
        azulText.SetActive(false);
        Invoke("vermelhoEscolhido",waitTime);
    }

    void azulEscolhido(){
        bcAzul.enabled=true;
        bcAmarelo.enabled=false;
        bcVermelho.enabled=false;
    }

    void vermelhoEscolhido(){
        bcVermelho.enabled=true;
        bcAzul.enabled=false;
        bcAmarelo.enabled=false;
    }

    void amareloEscolhido(){
        bcAzul.enabled=false;
        bcAmarelo.enabled=true;
        bcVermelho.enabled=false;
    }
}
