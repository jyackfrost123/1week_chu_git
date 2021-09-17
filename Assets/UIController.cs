using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour{

    public int score = 0;

    public float baseTime = 60.0f;
    private float time;
    public float deltaT = 0.5f;
    public float addTime = 5.0f;

    [SerializeField] private GameObject scoreUI;
    private Text scoreText;

    [SerializeField] private GameObject timeUI;
    private Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        time = baseTime;

        scoreText = scoreUI.GetComponent<Text>();
        timeText = timeUI.GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time -= Time.deltaTime * deltaT;
        timeText.text = ((int) time ).ToString("D2");

        scoreText.text = "スコア："+score;
    }

    public void AddScore(int point){
        score += point;
        time += addTime;
    }
}
