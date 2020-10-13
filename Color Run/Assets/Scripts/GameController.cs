using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject gameOver;
    public Text scoreText;
    public GameObject azulText;
    public GameObject amareloText;
    public GameObject vermelhoText;
    public float score;
    private PlayerController player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!player.isDead)
        score += Time.deltaTime * player.speed;
        scoreText.text = Mathf.Round(score).ToString() + "m";
    }

    public void ShowGameOver(){
        gameOver.SetActive(true);
    }

    public void azul(){
        azulText.SetActive(true);
        amareloText.SetActive(false);
        vermelhoText.SetActive(false);
    }
    public void amarelo(){
        amareloText.SetActive(true);
        vermelhoText.SetActive(false);
        azulText.SetActive(false);
    }
    public void vermelho(){
        vermelhoText.SetActive(true);
        amareloText.SetActive(false);
        azulText.SetActive(false);
    }
}
