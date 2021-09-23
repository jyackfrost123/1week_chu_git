using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouroufloatingController : MonoBehaviour
{
    [SerializeField] private float randomX = 0.002f; //0.004 Y = 0.0002
    [SerializeField] private float randomY = 0.0002f;
    [SerializeField] private float randomZ = 0.002f; 

    [SerializeField] public WaterFloat rand;
    // Start is called before the first frame update
    void Start()
    {
        rand = GetComponent<WaterFloat>();
        rand.MovingDistances = new Vector3(randomX * Random.Range(-1.0f, 1.0f), 
                                                 randomY * Random.Range(-1.0f, 1.0f),
                                                 randomZ * Random.Range(-1.0f, 1.0f)
                                                );
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Random.Range(0.0f, 1.0f) > 0.95f){
            rand.MovingDistances = new Vector3(  randomX * Random.Range(-1.0f, 1.0f), 
                                                 randomY * Random.Range(-1.0f, 1.0f),
                                                 randomZ * Random.Range(-1.0f, 1.0f)
                                                );

        }
    }
}
