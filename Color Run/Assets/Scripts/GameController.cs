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
    private GameObject[] bcAzul;
    private GameObject[] bcAmarelo;
    private GameObject[] bcVermelho;
    public float waitTime = 5f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        bcVermelho = GameObject.FindGameObjectsWithTag("Vermelho");
        bcAzul = GameObject.FindGameObjectsWithTag("Azul");
        bcAmarelo = GameObject.FindGameObjectsWithTag("Amarelo");

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
        foreach (GameObject item in bcAzul)
        {
            item.GetComponent<BoxCollider>().enabled = true;            
        }
         foreach (GameObject item in bcAmarelo)
        {
            item.GetComponent<BoxCollider>().enabled = false;            
        }
         foreach (GameObject item in bcVermelho)
        {
            item.GetComponent<BoxCollider>().enabled = false;            
        }
    }

    void vermelhoEscolhido(){
           foreach (GameObject item in bcAzul)
        {
            item.GetComponent<BoxCollider>().enabled = false;            
        }
         foreach (GameObject item in bcAmarelo)
        {
            item.GetComponent<BoxCollider>().enabled = false;            
        }
         foreach (GameObject item in bcVermelho)
        {
            item.GetComponent<BoxCollider>().enabled = true;            
        }
    }

    void amareloEscolhido(){
           foreach (GameObject item in bcAzul)
        {
            item.GetComponent<BoxCollider>().enabled = false;            
        }
         foreach (GameObject item in bcAmarelo)
        {
            item.GetComponent<BoxCollider>().enabled = true;            
        }
         foreach (GameObject item in bcVermelho)
        {
            item.GetComponent<BoxCollider>().enabled = false;            
        }

    }
}
