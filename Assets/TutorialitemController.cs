using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialitemController : MonoBehaviour
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
        InvokeRepeating("GenerateItems", 2.0f, 7.0f);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void GenerateItems(){


            Instantiate(prefab, new Vector3(Xlength * Random.Range(-1.0f, 1.0f), -2.0f, Zlength * Random.Range(-1.0f, 1.0f)), Quaternion.identity);

        //Instantiate(prefab, player.transform.position + new Vector3(Xlength * Random.Range(-1.0f, 1.0f), -2.0f, Zlength * Random.Range(-1.0f, 1.0f)), Quaternion.identity);



    }
}
