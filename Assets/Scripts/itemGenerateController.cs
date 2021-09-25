using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemGenerateController : MonoBehaviour
{

    [SerializeField] private float Zlength = 0;
    [SerializeField] private float Xlength = 0;
    [SerializeField] private float Rlength = 0;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject prefab;
    [SerializeField] private bool isFree = false;
    [SerializeField] private int itemNum = 0;
    [SerializeField] private int MaxNumItem = 0;
    public int ItemNum{
        set{this.itemNum = value;}
        get{return this.itemNum;}
    }
    

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("GenerateItems", 2.0f, 0.3f);
        InvokeRepeating("GenerateItems", 2.0f, 1.0f);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void GenerateItems(){

        if(ItemNum < MaxNumItem){//21 or 7
            if(isFree == true){
                //本当はこうしたい
                float rad = 2.0f*Mathf.PI*Random.Range(0.0f, 1.0f);
                Instantiate(prefab, player.transform.position + new Vector3(Rlength*Mathf.Cos(rad) , -2.0f, Rlength*Mathf.Sin(rad)+2.5f ), Quaternion.identity);
                ItemNum++;
            }else{
                Instantiate(prefab, new Vector3(Xlength * Random.Range(-1.0f, 1.0f), -2.0f, Zlength * Random.Range(-1.0f, 1.0f)), Quaternion.identity);
                ItemNum++;
            }

        }



        //Instantiate(prefab, player.transform.position + new Vector3(Xlength * Random.Range(-1.0f, 1.0f), -2.0f, Zlength * Random.Range(-1.0f, 1.0f)), Quaternion.identity);



    }
}
