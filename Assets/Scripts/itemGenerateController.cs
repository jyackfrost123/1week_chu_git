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

        if(isFree == true){
            //本当はこうしたい
            float rad = 2.0f*Mathf.PI*Random.Range(0.0f, 1.0f);
            Instantiate(prefab, player.transform.position + new Vector3(Rlength*Mathf.Cos(rad) , -2.0f, Rlength*Mathf.Sin(rad) ), Quaternion.identity);
        }else{
            Instantiate(prefab, new Vector3(Xlength * Random.Range(-1.0f, 1.0f), -2.0f, Zlength * Random.Range(-1.0f, 1.0f)), Quaternion.identity);
        }

        //Instantiate(prefab, player.transform.position + new Vector3(Xlength * Random.Range(-1.0f, 1.0f), -2.0f, Zlength * Random.Range(-1.0f, 1.0f)), Quaternion.identity);



    }
}
