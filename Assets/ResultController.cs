using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultController : MonoBehaviour
{

    [SerializeField] private int viewScore = 0;
    [SerializeField] private GameObject[] fires;
    // Start is called before the first frame update
    void Start()
    {
        //25個
        foreach(GameObject obj in fires){
            obj.SetActive(false);
        }

        StartCoroutine ("resultEffect");
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
        
        yield return null;
    }
}
