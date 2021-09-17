using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemController : MonoBehaviour{
    
    [SerializeField]private GameObject fire;

    [SerializeField]private UIController ui;
    [SerializeField]private int point = 10;
    
    [SerializeField]private GameObject player;
    [SerializeField]private bool isFire = false;

    // Start is called before the first frame update
    void Start(){
        fire.SetActive(false);
        ui = GameObject.Find("Canvas").GetComponent<UIController>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate(){
        if(player.transform.position.z > this.transform.position.z + 10.0f){
            Destroy(this.gameObject);
        }
    }

    /*void OnCollisionEnter(Collision other){

        if(other.gameObject.tag == "Player"){
            fire.SetActive(true);
        }
        
    }*/

    void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "Player" && isFire == false){
            fire.SetActive(true);
            ui.AddScore(point);
            isFire = true;
        }
    }
}
