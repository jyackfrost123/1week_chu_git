using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SmaphoCheckContollrt : MonoBehaviour
{

    Text SmaphoText;
    parametorController para;
    Image smaphoImage;

    // Start is called before the first frame update
    void Start()
    {
        //
        SmaphoText = transform.GetChild(0).gameObject.GetComponent<Text>();
        
        if(GameObject.Find("NCMBSettings") != null){
         para = GameObject.Find("NCMBSettings").GetComponent<parametorController>(); 
        }else{
            this.gameObject.SetActive(false);
        }

        smaphoImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(para.IsSmapho == true){
            SmaphoText.text = "スマホON";
            smaphoImage.color = new Color(255.0f/255.0f, 242.0f/255.0f, 0);
        }else{
            SmaphoText.text = "スマホOFF";
            smaphoImage.color = new Color(1, 1, 1);
        }
    }
}
