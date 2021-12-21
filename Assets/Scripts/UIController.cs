﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour{

    public int score = 0;

    public float baseTime = 60.0f;
    private float time;
    public float deltaT = 0.5f;
    public float addTime = 2.0f;

    parametorController para;
    public bool isEnd = false;
    public bool isStart = false;

    [SerializeField] private GameObject scoreUI;
    private Text scoreText;

    [SerializeField] private GameObject timeUI;
    private Text timeText;

    [SerializeField] private GameObject startUI;
    private Text startText;

    [SerializeField] private GameObject pad;
    public bool isPad = false;

    [SerializeField] private bool isFree = false;


    //public int 

    void Awake(){
        pad.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        time = baseTime;

        scoreText = scoreUI.GetComponent<Text>();
        timeText = timeUI.GetComponent<Text>();
        startText = startUI.GetComponent<Text>();

        if(GameObject.Find("NCMBSettings") != null){
         para = GameObject.Find("NCMBSettings").GetComponent<parametorController>(); 
         if(para.IsSmapho == true){
             pad.SetActive(true);
             isPad = true;
         }
        }

        StartCoroutine("GameStartCountdown");
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(isStart == true){
            time -= Time.deltaTime * deltaT;
            timeText.text = ((int) time ).ToString("D2");
        }

        if(time < 0.0f && isEnd == false){
            isEnd = true;
            if(para != null) para.OldScore = score;
            StartCoroutine("Finish");
            //SceneManager.LoadScene("ResultScene");
        }

        scoreText.text = "スコア："+score;
    }

    public void AddScore(int point){
        if(isEnd == false)score += point;
        if(isFree == true) time += addTime;
    }

    IEnumerator GameStartCountdown()  {
        //Instantiate(fireSE, this.transform.position , Quaternion.identity);
        float localTime = 4.0f;
        while(localTime > 2.0f){
            localTime -=1.0f;
            startText.text = ((int)localTime).ToString();
            yield return new WaitForSeconds (1.0f); 
        }

        startText.text = "開始"; 
        isStart = true;
        yield return new WaitForSeconds (1.0f);
        startText.text = ""; 
        //DOTweenSequence();
        yield return null;  
    }

    IEnumerator Finish()  {
        //Instantiate(fireSE, this.transform.position , Quaternion.identity);
        //yield return new WaitForSeconds (3.0f);  
        if(isFree == true){
                FadeManager.Instance.LoadScene ("ResultScene2", 1.5f);
            }else{
                FadeManager.Instance.LoadScene ("ResultScene", 1.5f);
        }
        //DOTweenSequence();
        yield return null;  
    }

}
