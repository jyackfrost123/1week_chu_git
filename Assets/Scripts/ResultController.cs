﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultController : MonoBehaviour
{

    [SerializeField] private int viewScore = 0;
    [SerializeField] private GameObject[] fires;

    parametorController para;

    [SerializeField] private GameObject HyoukaText;
    private Text hyoukaText;
    // Start is called before the first frame update
    void Start()
    {
        //25個
        foreach(GameObject obj in fires){
            obj.SetActive(false);
        }

        StartCoroutine ("resultEffect");

        if(GameObject.Find("NCMBSettings") != null){
         para = GameObject.Find("NCMBSettings").GetComponent<parametorController>();
         viewScore = para.OldScore; 
        }

        hyoukaText = HyoukaText.GetComponent<Text>();
        hyoukaText.text = "";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private IEnumerator resultEffect(){

        for(int i = 0; i < fires.Length; i++){
            if( viewScore  >  (10 * i) ){
                fires[i].SetActive(true);
                yield return new WaitForSeconds (0.15f);
            }
        }

        if(para != null) hyoukaText.text = para.HyokaMessage()+"級";
        else hyoukaText.text = old_HyokaMessage()+"級";
        
        yield return null;
    }

    public string old_HyokaMessage(){
        string s = "";

        if(viewScore < 50){
            s = "山火事";
            return s;
        }else if(viewScore < 100){
            s = "1/5文字";
            return s;
        }else if(viewScore < 150){
            s = "2/5文字";
            return s;
        }else if(viewScore < 200){
            s = "小文字";
            return s;
        }else if(viewScore < 250){
            s = "中文字";
            return s;
        }

        s = "大文字";
        return s;
    }
}
