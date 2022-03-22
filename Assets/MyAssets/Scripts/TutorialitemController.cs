using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialitemController : MonoBehaviour
{
    [SerializeField] private float Zlength = 0;
    [SerializeField] private float Xlength = 0;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject prefab;
    [SerializeField] private int tourouNum = 0;
    public int TourouNum{
        set{this.tourouNum = value;}
        get{return this.tourouNum;}
    }
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenerateItems", 2.0f, 2.0f);

    }

    void GenerateItems(){

        if(TourouNum < 6){
            
            Instantiate(prefab, new Vector3(Xlength * Random.Range(-1.0f, 1.0f), -2.0f, Zlength * Random.Range(-1.0f, 1.0f)), Quaternion.identity);
            TourouNum++;
        
        }

    }
}
